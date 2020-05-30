module LocalNetworkGraphTests

open NUnit.Framework
open LocalNetwork
open FsUnit

let testCases =
    [
        [[1]], ["Linux"; "Windows"], [0.3; 0.7], [0; 1]
        [[1]], ["Linux"; "Windows"], [1.0; 1.0], [0; 1]
    ] |> List.map (fun (communicationComputers, operSys, probabOfInf, infected) -> 
            TestCaseData(communicationComputers, operSys, probabOfInf, infected))

[<Test>]
[<TestCaseSource("testCases")>]
let ``Checks if the algorithm of infection works correctly`` communication operSys probabOfInf infected =
    LocalNetwork(communication, operSys, probabOfInf).Infected.Sort() |> should equal (List.sort infected)