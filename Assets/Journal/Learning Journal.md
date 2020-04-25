# *Learning Journal*

## Component 1: Light Blink

For the type of blink, I decided to use an `enum`, a value type that is used for selection. There is two main value that are used to modify the light: Frequency and amplitude. Each `enum` calculate a float, depending on input. First, I tried to calculate the new intensity as a **scale** of the base intensity. This was more difficult to achieve as the value had to varie around 1, and could not go negative.

Instead, I settled for **adding** the new value to base intensity. This proved easier to manage the calculations.

It took me some attempts to find a balance formula for the "ZeroAndBackAgain" type. It was also the first time I used a custom graph, type `AnimationCurve`. It is easy enough to use that I did not run into problem.

## Component 2: Antenna

I had used this system during a previous module, and simply improve the modularity of it. I wanted to be able to easily choose the length of antenna so I switch from a mesh base to a Line Renderer. Which in turn I had to provide a slot for the material, to give a better chance for creators to customise the look of the antenna.

## Component 3: Camera Shake

I decided to use a perlin noise for the camera shake, as it's fairly versatile and smooth to provide for movement. I started a regular shake on one plan, then decided to have the possibility to also shake on the z axis.

To smooth the fading in and out, I used an `AnimationCurve` representing the shake, and a curve going fading in to 1 and fading out back to 0. After testing, I decided to hard code the fading value, as they are very precise and change the result drastically if not in the right range.

The rest was straightforward, calculate an offset using noise, then applying it the camera position.

## Component 4: Slow-Motion

Slow motion is simply created by change the `Time.timeScale` to a value between 0 and 1. To keep the timer ticking at regular time, the Time class has a parameter to ignore the scale: `Time.unscaledDeltaTime`.

I change the call method to a static, so other script do not need a reference to that behaviour. I also had to change all the variables used to static.

The real difficulty was to figure out which moment of the slow motion is active (fade in, full slowmo, fade out). I created a series of `if` statements, but that could be improved as this is not ideal and makes expanding this behaviour difficult.

## Mini Game Project

Using the previously created component was quick and easy, showing that they worked the way intended, without needed to be tweaked. Moving the character and shooting are relatively simple script.

I had more trouble to make the aim work. I wanted the player to aim where the mouse was pointing in world position, but on the same horizontal plane. Looking around, I found the `Plane` type, which I never used before. As the name implies, it create a virtual plane, which I used horizontally at the player aim height. It also come with a way of directly shooting a ray and finding the point it touch. From there we only shoot a ray from camera to the plane at the mouse position.
