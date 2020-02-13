namespace FSharpClassLibrary

type IntOrBool = 
  | I of int
  | B of bool
  | X


type RobotState = 
    | Unknown 
    | Up
    | Down

type Shape =
    | Rectangle of width : float * length : float
    | Circle of radius : float
    | Prism of width : float * float * height : float

type Option<'a, 'b> =
    | Some of 'a * 'b
    | None