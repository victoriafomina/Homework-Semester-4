module LocalNetwork

open System
open System.Collections.Generic


/// Local network working process model.
type LocalNetwork(computersCommunication: bool list list, OSOfComputers: string list, probabilityInfectionForOS: float list) =

    /// Infected computers.
    let mutable infected = new List<int>()

    /// Number of computers in local network.
    let numberOfComputers= List.length computersCommunication

    /// Random numbers sensors for computers. On every step check if the computer is infected.
    let rndNumbersSensors = new List<Random>()

    /// Checks if the current step infects computer.
    let isInfectedThisStep probabilityOfInfection randomSensorValue = randomSensorValue >= probabilityOfInfection

    /// Returns the probability to be infected for computer with specific OS.
    let probabylityOfInfectionForOS operSys = probabilityInfectionForOS.[List.findIndex (fun x -> x = operSys) OSOfComputers]

    /// Finds probabylity of infection for computer.
    let probabilityOfInfection vertex = probabylityOfInfectionForOS <| OSOfComputers.[vertex]

    /// Checks if the network can be infected.
    let networkCanBeInfected = List.exists (fun x -> abs(x) > 0.001) probabilityInfectionForOS

    /// Checks if the neighbours of the computer can be infected.
    let neighboursCanBeInfected vertex =
        List.exists2 (fun el1 el2 -> el1 && abs(el2) > 0.001) computersCommunication.[vertex] probabilityInfectionForOS

    /// Checks if it is possible to infect some computer.
    //let someCanBeInfected = 
    //    List.exists (fun x -> neighboursCanBeInfected x.) computersCommunication

    /// Infects all the vertexes that are possible to infect.
 (*   let infectAll =
        if infected.Count = numberOfComputers || not (infected.Exists(fun x -> neighboursCanBeInfected x)) then 0
        else
            infected.FindAll(fun x -> isInfectedThisStep (probabilityOfInfection x) (rndNumbersSensors.[x]).Next(0, 100))
*)
        
