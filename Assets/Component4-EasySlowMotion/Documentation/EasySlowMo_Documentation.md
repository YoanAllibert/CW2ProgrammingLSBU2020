# *Easy Slow Motion Documentation*

This documentation explains how  to use the *EasySlowMotion* package for Unity.

*EasySlowMotion* is a simple and effective way to iniate a slow motion effect at the precise moment needed, and using parameter to customise the effect.

## *EasySlowMotion Component*

This *contains* all the necessary code to run a **slow motion effect**. This script needs to be place inside *any* gameobject in any scene where you wish to use it. Only **one** copy is necessary per scene, and it can be place in any *GameObject*. We recommend placing it in an object always present in the scene, like a *camera*.

## *Instantiate a new Slow Motion*

A static method can be called from *anywhere* inside another script, like this:

```c#
EasySlowMotion.StartSlowMo(float scale, float fadeIn, float duration, float fadeOut);
```

The four parameters (*scale, fadeIn, duration, fadeOut*) needs to be replace by the *floating point numbers* you wish to use:

* **Scale**: This scale the passing time during the slow motion. Range from 0 (time stop), to 1 (normal time). For example, *0.1* slows down time to 10%.
* **Fade In**: the time it takes to reach the desired slow motion. This ease in the slow. Note: It *adds* to the total duration.
* **Duration**: How long the slow motion last at the desired scale. This does not incle fadeIn or fadeOut.
* **Fade Out**: Once *duration* is over, slowly transition back to normal scale. This ease out the slow. Note: It *adds* to the total duration.

## *Examples*

To create a short slow motion that quickly fades in and out, try this code in an `Update` method:

```c#
if (Input.GetKeyDown(KeyCode.Space))
    EasySlowMotion.StartSlowMo(0.3f, 0.1f, 2f, 0.1f);
```

For a longer slow motion, with  slower fades, try:

```c#
if (Input.GetKeyDown(KeyCode.Space))
    EasySlowMotion.StartSlowMo(0.1f, 1.2f, 3f, 1.2f);
```
