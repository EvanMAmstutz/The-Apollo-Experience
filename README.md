#The Apollo Expereince

### Description
The Apollo Experience, supported by Google Cardboard, depicts the Apollo missions to the moon. Experience a scientifically accurate depiction of the lunar landings. The goal of the game is to follow NASA's directions and explore the lunar environment before its time to return to Earth. Tasks include collecting samples, taking pictures, and planting the American flag.

### Motivation
We wanted to find a moment in history with a lot of significance, which also has many misconceptions. We chose the Apollo moon landing to teach people the facts about the moon including, but not limited to, the lack of stars in the sky, the way the astronauts had to move, and the lack of sound on the moon.

### Technical Explanation
Our project consists of movement around the environment using a hopping motion for both the user's character and the AI character. The user's character hopping movement was created by manipulating the First Person Controller script so, as long as the user is grounded, a directional movement with the controller results in a hopping motion. For the AI character, the hopping motion was achieved by using Maximo to apply the animation to the AI asset. This was then exported to Unity where the animation was manipulated to include motion along the x-axis. 

The sample collection system was created using mesh colliders placed on the rock assets and making the user character asset a rigid body object. A collision with the rock asset triggers a an action which picks up the rock. 
### Game Screenshots

### Gameplay Video


### Authors and Contributors
Evan Amstutz (@EvanMAmstutz), Erian Vazquez (@ErianVazquez), and Patrick Poplowska (@ppoplawska) worked on this project in Spring 2016 for the University of Florida's Virtual Reality class taught by Benjamin Lok.

### References
We used some models from different developers in our experience. Those models are listed below.
