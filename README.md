# Cloth Simulation Project

This project is a cloth simulation system based on the scientific paper "Deformation Constraints in a Mass-Spring Model to Describe Rigid Cloth Behavior" by Xavier Provot¹²³. 

![Final Cloth Rami BenDhia Video (1)](https://github.com/MrRamiBenDhia/MyPhysicsEngine/assets/112359223/9fb51c4b-89f1-442c-a06f-fd18193b0aa8)
## Overview

The simulation system couples a new technique for enforcing constraints on individual cloth particles with an implicit integration method³. It takes into account the non-elastic properties of woven fabrics¹². The cloth object is approximated with a deformable surface network of masses and springs¹². The movement of the cloth is evaluated using the numerical integration of the fundamental law of dynamics¹².

## Simulation Details

The system is the mesh of m x n masses, each mass with position at time t given by Pi,j(t). The evolution of the system is governed by the fundamental law of dynamics: F i,j =  i,j where is the mass at point Pi,j(t), and a i,j is the acceleration caused by the force F i,j¹. 

Internal forces are tensions of interconnected springs which are described by Hooke’s Law: F = k · u where F is the applied force, u  is the deformation (displacement from equilibrium) of the elastic body subjected to the force  F, and  k is the spring constant¹. 

External forces include the force of gravity Fgr(P i,j) =     g where g  is the acceleration of gravity and viscous damping Fdis(P i,j) = -C disv i,j where C dis is the damping coefficient and velocity at point Pi,j¹.

## Demo

A short video showcasing the project will be added soon.

## References

1. Xavier Provot, ["Deformation Constraints in a Mass-Spring Model to Describe Rigid Cloth Behavior"](https://www.researchgate.net/publication/2491824_Deformation_Constraints_in_a_Mass-Spring_Model_to_Describe_Rigid_Cloth_Behavior).
