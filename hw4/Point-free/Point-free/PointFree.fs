module PointFree

// To point-free.

let multiply1 x l = List.map (fun y -> y * x) l

let multiply2 x = List.map (fun y -> y * x)

let multiply3 x = List.map (*) x

// Point-free version. Multiplies the elements of the list.
let multiplyPointFree = List.map (*)