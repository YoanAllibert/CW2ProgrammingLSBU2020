# *Antenna Component Documentation*

This *documentation* explain how to use the *Antenna* component, which is used to create Line based, physics affected antennas.

## *Behaviour*

* Antenna Prefab
* [`AntennaScript`]

## *Antenna Prefab*

This prefab contain the assembled component. To use, simply *drag and drop* onto the scene or the hierarchy. The **pivot** of this object is the base of the antenna. place and rotate into the desired position. This gives you control of the direction at rest. The length of the antenna will be controlled by the script.

## *AntennaScript*

The *behaviour* is attached to the *parent* game object of the Antenna *Prefab*. It contains different parameters to adjust the **visual** and **physics** of the antenna.

## *Parameters*

There is two categories of parameters available to tweak:

### Line Parameters

These controls the visuals of the line.

* *Length*: The length of the antenna. Please note that it will be applied at runtime. 
* *Base Width*: How large the width of the base is. It is recommended to keep this number pretty small, between 0.01 and 0.03. 
* *Material To Use*: The material that will be assigned to the LineRenderer. You can create your own. Note that the shader used needs to be compatible with the *Line Renderer* Component. In Unity these are the **Sprites** shader or **Particles** shader.

### Physics Parameters

Affects the reaction to movement.

* *Spring Force*: The bounciness of the spring, or the force the spring applies to try and reach the target position. Higher number means faster bounciness.
* *Drag*:  The opposite force that slow downs the antenna. A higher number means less bounciness, and a faster reach to target position.

## Usage

The *Antenna prefab* can be used as a child of any Game Object. It does not require the parent object to be affected by physics, it will automatically react to any movement affecting it's *Transform*.

[`AntennaScript`]: #AntennaScript
