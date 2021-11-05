# Bend and Reach

## Unity Version

2021.1.21f1
Built and tested on Oculus Quest 2, Both by sideloading from unity or running via link mode

## Inspiration

Replicating https://www.skimble.com/exercises/29622-bend-and-reach-how-to-do-exercise 

## HOW TO Play
1. Reach out to touch the play button to start game. (this was done beause touching is a more simple interaction for new VR users than the pointer)
2. Use the primary button to pause game and return to main menu.

## Gameplay

The gameplay I went for was something that pushed the player to stand up straight and straighten arms as well as bend down. 
To achieve this, I placed two buttons above the player i.e top left and top right of the player. Placed an area that contains balls that can be picked up and then a goal in front of the player that balls can be thrown at. 
 Steps of Gameplay:
 1. Player has to REACH up to touch either of the buttons
 2. When touched, balls appear on the ground and player now has to BEND to pick up ball
 3. For extra points, player needs to throw the ball at the goal. 
 4. If ball enters goal, player has a limited time to touch buttons again. 
 5. Within this time, player gets combo balls that give more points and have more speed. So easier to throw. 
 6. If player doesnt do it fast enough, normal balls will be generated when button is pressed. 
 7. Player also gets motivation messages when they get balls into the goals.
 8. In a finished version, there would be a better tutorial, sounds and more explanation on how to play. There was simply not enough time to implement this 

## Game Setup

### Data Setup
All data objects can be found at Assets\Scripts\Data\Resources

Most parameters of the game is controlled by the GameConfigHolder. These paramters are stored in a scriptable object that can be assigned or loaded at runtime. In a finished version. Progression can be added, by varying these paramters to give progress to patients. For example, the distance of the buttons above the player, can be placed higher if you really want the player to reach, or lower for patients that are really in pain. Same with the balls below. they can be placed so its more easier or difficult to pick up. This also applied to the goal location.
The idea is to make sure all paramters are easily configurable.

### Gameplay Logic
Events and components drive the entirity of the gameplay. A simplified system to listen to events via interfaces is greatly used all over the gameobjects. This makes it easier for gameobjects to get updates for the different states of the game. 
Direct references of gameobject in the scene are not really used, apart from in few cases. The only direct references used are for paramters from the assets folder. 

This setup makes it easy for the classes to be independent of the scene and the availability of other scripts. 

### Events Data 
A unified scriptable object holds all data for events, this is important because it makes it easier to debug the classes calling and using the events. A combination of this and interfaces for subcribing and unsunscribing to events also makes it easy for developers to easily extend in the future to add more events. It also simplifies how subscribing to events occur, since you dont always have to add and remove listeners. A simple component can do this for you. You only need to implement an interface to receive an event .

### Timers
Timing is used for some gameplay elements and as such, a timing system already developed is utilised for this. The abstract timer makes it easy to start and end multiple timers while attaching callbacks for when they compelete.

### UI System
A simple ui system is used for showing and hiding ui elements. 
For the mainmenu buttons. Touch via collision is used to trigger interaction 

## Systems 

### Event System
### Detection System 
### UI System 
### Timing System

