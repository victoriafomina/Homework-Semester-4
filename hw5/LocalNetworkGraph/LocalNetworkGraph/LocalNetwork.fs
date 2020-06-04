module LocalNetwork

open System
open System.Collections.Generic   


/// Local network working process model.
type LocalNetwork(computersCommunication: int list list, OSOfComputers: string list, probabilityInfectionForOS: float list) =

    /// Infected computers.
    let infected = new List<int>()

    /// Infected this step.
    let newInfected = new List<int>()

    /// Number of computers in local network.
    let numberOfComputers () = List.length computersCommunication

    /// Random number sensor for computers. On every step check if the computer is infected.
    let rndSensorValue = new Random()

    /// Returns the probability to be infected for computer with specific OS.
    let probabylityOfInfectionForOS operSys = probabilityInfectionForOS.[List.findIndex (fun x -> x = operSys) OSOfComputers] * 100.0

    /// Finds probabylity of infection for computer.
    let probabilityOfInfection vertex = probabylityOfInfectionForOS <| OSOfComputers.[vertex]

    /// Checks if the current step infects computer.
    let isInfectedThisStep vertex =
        probabilityOfInfection vertex >= double(rndSensorValue.Next(0, 100))

    /// Checks if the network can be infected.
    let networkCanBeInfected = List.exists (fun x -> abs(x) > 0.001) probabilityInfectionForOS

    /// Checks if the neighbours of the computer can be infected.
    let neighboursCanBeInfected vertex =
        List.exists (fun x -> not <| infected.Contains x && abs(probabilityOfInfection x) > 0.001) computersCommunication.[vertex]

    /// Tries to infect neighbours.
    let tryInfectNeighbours vertex =
        computersCommunication.[vertex] 
        |> List.iter (fun x -> if not (infected.Contains x) && isInfectedThisStep x then newInfected.Add x)

    /// Infects first computer.
    let infectFirst () = 
        let rec infectFirstRec acc =
            if isInfectedThisStep acc then acc
            else infectFirstRec <| (acc + 1) % numberOfComputers()
        infectFirstRec 0

    /// Prints the information about the state of the network.
    let printInf () =
        let rec printRec currVertex =
            if currVertex < numberOfComputers() then 
                if infected.Contains(currVertex) then printfn "%s%d" "INFECTED: " currVertex
                else printfn "%s%d" "Not infected: " currVertex
                printRec (currVertex + 1)
                printf "%s" "\n"
        printRec 0

    /// Infects all the vertexes that are possible to infect.
    let rec infectAll =
        if not networkCanBeInfected then infected
        else
        let rec infectAllRec acc =            
            if infected.Count = 0 then
                infected.Add(infectFirst ())
                printInf ()
                infectAllRec 0
            elif (infected.Count = numberOfComputers () || infected.TrueForAll(fun x -> not <| neighboursCanBeInfected x)) then infected
            else 
                infected.ForEach(fun x -> tryInfectNeighbours x)
                infected.AddRange(newInfected)
                newInfected.Clear()
                printInf ()
                infectAllRec 0
        infectAllRec 0    
        
    /// Infects all the computers with virus. Returns infected computers.
    member public this.Infected = infectAll
