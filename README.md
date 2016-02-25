#The Apollo Expereince

### Description
The Apollo Experience, supported by Google Cardboard, depicts the Apollo missions to the moon. Experience a scientifically accurate depiction of the lunar landings. The goal of the game is to follow NASA's directions and explore the lunar environment before its time to return to Earth. Tasks include collecting samples, taking pictures, and planting the American flag.

### Motivation
We wanted to find a moment in history with a lot of significance, which also has many misconceptions. We chose the Apollo moon landing to teach people the facts about the moon including, but not limited to, the lack of stars in the sky, the way the astronauts had to move, and the lack of sound on the moon.

### Technical Explanation
Our project consists of movement around the environment using a hopping motion for both the user's character and the AI character. The user's character hopping movement was created by manipulating the First Person Controller script so, as long as the user is grounded, a directional movement with the controller results in a hopping motion. For the AI character, the hopping motion was achieved by using Mixamo to apply the animation to the AI asset. This was then exported to Unity where the animation was manipulated to include motion along the x-axis. 

The sample collection system was created using mesh colliders placed on the rock assets and making the user character asset a rigid body object. A collision with the rock asset triggers an action which picks up the rock, destroying the asset and setting a boolean flag to true. When the sample is brought back to the lander asset, a collision is activated and the boolean flag is set to false. 

A picture can be taken by selecting the proper button on the controller, thus playing a camera click audio file. The final action is putting the American flag on the moon. This was done by exploiting the user being in first person and hiding the flag directly above the user's camera and turning off the mesh render associated with the flag asset. When the player gets within a certain range of the planting point, the mesh render is turned on and an animation is activated lowering the flag asset to the ground and detaching it from the parent, which is the First Person Controller.

###Learning Objectives
* Not being able to see stars at the Apollo 11 landing site
* Activities the astronauts did on the Moon
* How bright the sun is without Earth's atmosphere
* How light objects are with the Moon's gravity
* Lack of sound on the Moon
* The limited technology that was at the astronaut's disposal, as displayed by the radio quality

### Game Screenshots


### Gameplay Video


### Website
http://evanmamstutz.github.io/The-Apollo-Experience/


### Authors and Contributors
Evan Amstutz (@EvanMAmstutz), Erian Vazquez (@ErianVazquez), and Patrick Poplowska (@ppoplawska) worked on this project in Spring 2016 for the University of Florida's Virtual Reality class taught by Benjamin Lok.

### References
We used some models from different developers in our experience. Those models are listed below.

[Lander and lunar astronaut suit](http://nasa3d.arc.nasa.gov/models)

[Lunar rocks](https://www.assetstore.unity3d.com/en/#!/content/6947)

[Breathing sound effect](https://www.youtube.com/watch?v=Wt7b8RyRfWw)

[Maximo Tutorial](https://www.youtube.com/watch?v=mBbXPB_6SWs)

[American Flag](https://3dwarehouse.sketchup.com/model.html?id=c34b64f276c670f349bb7846d039ee8)

[Smooth rotation code](http://forum.unity3d.com/threads/smooth-look-at.26141/)

[User helmet](https://3dwarehouse.sketchup.com/model.html?id=ubdd49a99-679f-460e-844e-5dcbdca48a85)

[Lunar landscape](https://www.assetstore.unity3d.com/en/#!/content/35818)
