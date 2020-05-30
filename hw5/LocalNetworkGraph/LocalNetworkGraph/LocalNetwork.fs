module LocalNetwork

open System
open System.Collections.Generic


/// Local network working process model.
type LocalNetwork(computersCommunication: int list list, OSOfComputers: string list, probabilityInfectionForOS: float list) =
    
    /// Infected computers.
    let mutable infected = new List<int>()

    /// Number of computers in local network.
    let numberOfComputers= List.length computersCommunication

    /// Random numbers sensors for computers. On every step check if the computer is infected.
    let rndSensorValues = new List<Random>()

    /// Returns the probability to be infected for computer with specific OS.
    let probabylityOfInfectionForOS operSys = probabilityInfectionForOS.[List.findIndex (fun x -> x = operSys) OSOfComputers]

    /// Finds probabylity of infection for computer.
    let probabilityOfInfection vertex = probabylityOfInfectionForOS <| OSOfComputers.[vertex]

    /// Checks if the current step infects computer.
    let isInfectedThisStep vertex = (probabilityOfInfection vertex).CompareTo(rndSensorValues.[vertex].Next(0, 100)) < 0

    /// Checks if the network can be infected.
    let networkCanBeInfected = List.exists (fun x -> abs(x) > 0.001) probabilityInfectionForOS

    /// Checks if the neighbours of the computer can be infected.
    let neighboursCanBeInfected vertex =
        List.exists (fun x -> abs(probabilityInfectionForOS.[x]) > 0.001) computersCommunication.[vertex]

    /// Tries to infect neighbours.
    let tryInfectNeighbours vertex =
        computersCommunication.[vertex] |> List.iter (fun x -> if not (infected.Contains x) && isInfectedThisStep x then infected.Add x)

    /// Infects first computer.
    let infectFirst = 
        let rec infectFirstRec acc =
            if isInfectedThisStep acc then acc
            else infectFirstRec (acc + 1) % numberOfComputers
        infectFirstRec 0

    /// Infects all the vertexes that are possible to infect. НЕЛЬЗЯ ЛИ БЕЗ АККУМУЛЯТОРА?
    let infectAll =
        let rec infectAllRec acc =
            if infected.Count = numberOfComputers || not (infected.Exists(fun x -> neighboursCanBeInfected x)) then 0
            elif infected.Count = 0 then 
                infected.Add(infectFirst)
                infectAllRec 0
            else 
                infected.ForEach(fun x -> tryInfectNeighbours x)
                infectAllRec 0
        infectAllRec 0
    
    /// Infects all the computers with virus.
    member public this.Infect = if networkCanBeInfected then infectAll else -1
