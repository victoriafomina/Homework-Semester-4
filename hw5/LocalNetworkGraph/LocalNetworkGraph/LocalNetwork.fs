module LocalNetwork

open System
open System.Collections.Generic


/// Local network working process model.
type LocalNetwork(computersCommunication: int list list, OSOfComputers: string list, probabilityInfectionForOS: float list) =

    /// Infected computers.
    let mutable infected = new List<int>()

    /// Infected this step.
    let mutable newInfected = new List<int>()

    /// Number of computers in local network.
    let numberOfComputers = List.length computersCommunication

    /// Random numbers sensors for computers. On every step check if the computer is infected.
    let rndSensorValues = new List<Random>()

    /// Initializes the list of random numbers sensors.
    let init = 
        let rec initRec acc =
            if acc = numberOfComputers then acc
            else 
                rndSensorValues.Add(new Random())
                initRec (acc + 1)
        initRec 0

    do init |> ignore

    /// Returns the probability to be infected for computer with specific OS.
    let probabylityOfInfectionForOS operSys = probabilityInfectionForOS.[List.findIndex (fun x -> x = operSys) OSOfComputers] * 100.0

    /// Finds probabylity of infection for computer.
    let probabilityOfInfection vertex = probabylityOfInfectionForOS <| OSOfComputers.[vertex]

    /// Checks if the current step infects computer.
    let isInfectedThisStep vertex =
        (probabilityOfInfection vertex).CompareTo(double(rndSensorValues.[vertex].Next(0, 100))) >= 0

    /// Checks if the network can be infected.
    let networkCanBeInfected = List.exists (fun x -> abs(x) > 0.001) probabilityInfectionForOS

    /// Checks if the neighbours of the computer can be infected.
    let neighboursCanBeInfected vertex =
        List.exists (fun x -> abs(probabilityInfectionForOS.[x]) > 0.001) computersCommunication.[vertex]

    /// Tries to infect neighbours.
    let tryInfectNeighbours vertex =
        computersCommunication.[vertex] |> List.iter (fun x -> if not (infected.Contains x) && isInfectedThisStep x then newInfected.Add x)

    /// Infects first computer.
    let infectFirst = 
        let rec infectFirstRec acc =
            if isInfectedThisStep acc then acc
            else infectFirstRec <| (acc + 1) % numberOfComputers
        infectFirstRec 0

    /// Infects all the vertexes that are possible to infect. НЕЛЬЗЯ ЛИ БЕЗ АККУМУЛЯТОРА?
    let infectAll =
        if not networkCanBeInfected then infected
        else
        let rec infectAllRec acc =            
            if infected.Count = 0 then 
                infected.Add(infectFirst)
                infectAllRec 0
            elif infected.Count = numberOfComputers || not (infected.Exists(fun x -> neighboursCanBeInfected x)) then infected
            else 
                infected.ForEach(fun x -> tryInfectNeighbours x)
                infected.AddRange(newInfected);
                newInfected.Clear();
                infectAllRec 0
        infectAllRec 0
    
    /// Infects all the computers with virus. Returns infected.
    member public this.Infect = infectAll

    /// Returns the infected computers.
    member public this.Infected = infected
