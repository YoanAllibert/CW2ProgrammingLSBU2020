# Light Blink Component Documentation

This *documentation* explain the behaviour of the *Light Blink* component, which is used to *flicker* any light with a chosen method and explain the different *parameters* and how to use them.

## Behaviour

[`LightBlink`]

## LightBlink

The *behaviour* can be attached to any Unity light that uses the built-in `Light` component. It will only influence the *intensity* over time without changing the light mode, range or type.

## Parameters

The behaviour has a number of *parameters* to get to the desired effects. Note that we call the `base intensity` the default intensity of the light. The *parameters* are explained below:

### Type

The *mode* in which the light is affected. There are *six* different types. If a type is affected by other parameters, it is mentioned in the description.

* **None**: *Default* parameters, no flickering is applied. Note: the light will be reset to `base intensity` if change at runtime.
  
* **Sinusoidal**: A change in intensity that follow a Sine wave curve. The light intensity will go *up*, *down* and *up* again with passing time, with a middle point at `base intensity`. Affected by: *Frequency*, *Amplitude*.
  
* **Zero and back again**: As the name imply, the light will start from `base intensity`, smoothly change to zero, and goes back to starting value over time. Affected by: *Frequency*.
  
* **Random**: Every frame, the intensity will change for a value near `base intensity`. Affected by: *Amplitude*.
  
* **Random Perlin noise**: Using a random noise, this type will smoothly move the light to a random value around the `base intensity`. Affected by: *Frequency*, *Amplitude*.
  
* **From Graph**: Used to precisely *control* the intensity of the light using a curve. The X axis represent the time and should have a range of *0 to 1*. Anything over 1 will not affect the light, the graph will restart to 0 when reaching 1. For best result, the value at 0 and 1 should be the same to avoid a sudden change in intensity. The Y axis represent the change in intensity. A value under 0 will reduce the intensity, over 0 will increase it, and a value of exactly 0 is equal to `base intensity`. Affected by: *Frequency*, *Amplitude*

### Frequency

Affects the passing of time. A frequency of 1 will result in the base time. Between 0 and 1 will slow down the change in intensity. Over 1 will accelerate the change. Not all types are affected by frequency, see the [Type] chapter for more info.

### Amplitude

Affects the value (range) in the change of intensity. An amplitude of 1 uses the base value of the change. Between 0 and 1 will reduce the value of the affected intensity. Over 1 will scale up the ammount of changing intensity. Not all types are affected by Amplitude, see the [Type] chapter for more info.

### Graph

The chosen curve to affect the light when using `From Graph` type. see the [Type] chapter for information on the value to use. The graph is useful to customise the intensity, giving precise control over the way the intensity is affected.

[`LightBlink`]: #LightBlink
[Type]: #Type
