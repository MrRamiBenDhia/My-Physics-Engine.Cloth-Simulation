# Cloth Simulation Project

This project is a cloth simulation system based on the scientific paper "Deformation Constraints in a Mass-Spring Model to Describe Rigid Cloth Behavior" by Xavier Provot¹²³. 
![Screenshot of the scientific paper](https://github.com/MrRamiBenDhia/My-Physics-Engine.Cloth-Simulation/assets/112359223/cd221ba2-75c0-49a1-a7c9-5a64a5e97fc1)

## Overview

The simulation system couples a new technique for enforcing constraints on individual cloth particles with an implicit integration method³. It takes into account the non-elastic properties of woven fabrics¹². The cloth object is approximated with a deformable surface network of masses and springs¹². The movement of the cloth is evaluated using the numerical integration of the fundamental law of dynamics¹².

## Simulation Details

The system consists of an m x n mesh of masses, where each mass at position `P(i, j, t)` evolves over time `t`.
The motion of the masses is governed by the fundamental law of dynamics: `F(i, j) = m * a(i, j)`, 
where `m` is the mass at point `P(i, j, t)`, and `a(i, j)` is the acceleration caused by the force `F(i, j)`.

Internal forces arise from the tensions of interconnected springs, which are described by Hooke’s Law: `F = k * u`, where `F` is the applied force, 
`u` is the deformation (displacement from equilibrium) of the elastic body subjected to the force `F`, and `k` is the spring constant¹.

External forces include the force of gravity `F_gr(P(i, j)) = g`, where `g` is the acceleration due to gravity,
and viscous damping `F_dis(P(i, j)) = -C_dis * v(i, j)`, where `C_dis` is the damping coefficient and `v(i, j)` is the velocity at point `P(i, j)`.

## Demo

<!-- ![Final Cloth Rami BenDhia Video (1)](https://github.com/MrRamiBenDhia/MyPhysicsEngine/assets/112359223/9fb51c4b-89f1-442c-a06f-fd18193b0aa8) -->

| Description       | Preview                                                                                                     |
|-------------------|--------------------------------------------------------------------------------------------------------------|
| Touch and Drag    | ![Touch and Drag](https://github.com/MrRamiBenDhia/MyPhysicsEngine/assets/112359223/28d232d5-e710-4985-8558-c3a2c75485e4) |
| Gravity           | ![Moving Bar](https://github.com/MrRamiBenDhia/MyPhysicsEngine/assets/112359223/fdf1ba00-5b46-44e5-809f-6948d7b2c198) |
| Wind Force        | ![Wind Force](https://github.com/MrRamiBenDhia/MyPhysicsEngine/assets/112359223/bf6defa4-46e0-4fdc-8185-7735738c1919) |

## References

1. Xavier Provot, ["Deformation Constraints in a Mass-Spring Model to Describe Rigid Cloth Behavior"](https://www.researchgate.net/publication/2491824_Deformation_Constraints_in_a_Mass-Spring_Model_to_Describe_Rigid_Cloth_Behavior).
