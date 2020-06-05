module LocalNetwork

open System


/// Local network working process model.
type LocalNetwork(computersCommunication: int list list, OSOfComputers: string list, probabilityInfectionForOS: float list) =

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
    let neighboursCanBeInfected vertex infected =
        List.exists (fun x -> not (List.contains x infected) && abs(probabilityOfInfection x) > 0.001) computersCommunication.[vertex]

    /// Tries to infect neighbours.
    let tryInfectNeighbours infected vertex =
        let rec tryInfectNeighboursRec infected vertex currVrtx =
            if currVrtx = numberOfComputers() then infected
            elif isInfectedThisStep currVrtx && not (List.contains currVrtx infected) && List.contains currVrtx computersCommunication.[vertex] then
                tryInfectNeighboursRec (currVrtx :: infected) vertex (currVrtx + 1)
            else tryInfectNeighboursRec infected vertex (currVrtx + 1)
        tryInfectNeighboursRec infected vertex 0

    /// Infects first computer.
    let infectFirst () = 
        let rec infectFirstRec acc =
            if isInfectedThisStep acc then acc
            else infectFirstRec <| (acc + 1) % numberOfComputers()
        infectFirstRec 0

    /// Prints the information about the state of the network.
    let printInf infected =
        let rec printRec infected currVertex =
            if currVertex < numberOfComputers() then 
                if List.contains currVertex infected then printfn "%s%d" "INFECTED: " currVertex
                else printfn "%s%d" "Not infected: " currVertex
                printRec infected (currVertex + 1)
                printf "%s" "\n"
        printRec infected 0

    /// Infects all the vertexes that are possible to infect.
    let rec infectAll =
        if not networkCanBeInfected then []
        else
        let rec infectAllRec infected =            
            if List.length infected = 0 then
                printInf infected
                infectAllRec (infectFirst () :: infected)
            elif (List.length infected = numberOfComputers () || List.forall (fun x -> not (neighboursCanBeInfected x infected)) infected) then infected
            else 
                printInf infected                
                infectAllRec (List.map (fun x -> tryInfectNeighbours infected x) infected |> List.concat)
        infectAllRec []    
        
    /// Infects all the computers with virus. Returns infected computers.
    member public this.Infected = infectAll
