module Sphere

let circle_S radius =
    let pi = 3.14
    pi*radius*radius;

let add_length = fun circle length ->
    circle*length;

let cilinder_S_compose = circle_S >> add_length

let cilinder_S_carry radius length =
    add_length (circle_S radius) length

