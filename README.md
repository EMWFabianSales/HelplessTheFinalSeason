# HelplessTheFinalSeason

## Changelog

### January 9th 2023 10:45 PM PST
**Host: Mina**

Began modeling Nao's Map, still **heavily** work in progress
so far only got the first floor's floor and the floor of the Church Building done.

we've also errected the walls for both, that being said neither one is done, still going through and punching out holes for windows and fixing N-gons, merging broken vertices and generally just doing the painstaking work of making this model work, also trying to literally cut corners, specifically we're trying to see where we can reduce the Vertex count for performance and to see where we can split the model in order to allow Unity To cull unseen sections.

side note, for the Church Building we used a mirror filter because nothing says pretentious perfectionism like symetry.

soon we're gonna run into a huge problem, textures, fortunately we should have some textures that could work for the church, that being said we are going to need to go on a goose hunt for textures to toss into the main assylum building


### January 10th 2023 10:45 PM PST
**Host: Shean**

Modified the `GenerateClutter` function in the `GameManager` Script, not finished yet, but have begun adding seperate Generation passes to allow for a set amount of each kind of trash
also looking into making an instanceable version of the script to allow individual groups of clutter completely independent of one another allowing for different sections to have more of one kind of clutter than another

### January 12th 2023 10:12 PM PST
Host: Shean

Continued to modify the `GenerateClutter` function in the `GameManager` Script, created a list object which creates new instances of procedurally generated zones. This Instatiated Script allows for each individual zone to be modified from position to zone size, currently this zone can only generate Medical Prefabs, this Instanciable script also allows for the dev to manually modify how much of each type of item generates, currently the script only generates Medical Supplies, but has options for Books, Papers, Rubble(W.I.P), planned to add is other small pieces of trash such as bottles and wrappers.

Also added comments to make reading code easier, general rule of thumb is to write comments as if someone else **WILL** read, since regardless it's future you who will have to deal with it.


### January 13th 2023 11:44 PM PST
**Host: Mina**

We've continued to work on modifying the `GenerateClutter` function. It seems to be more or less done the current features includes the following:
- Multiple passes to streamline the generation
- Precise control over quantity of generated items
- Precise control over Generation Area and Postion
- Randomized Postioning of generated items within the designated Generation Area
- Randomized Rotation of generated Items

Unfortunately we still need to add position validation to ensure that items don't overlap often, we've made sure to leave lots of comments to make it at least somewhat easier to read, although even then it is still a bit confusing, seperately we've added labels and outlines to show where individual Designated groups position and area covers as well as labels which show quantities of items each group is designated to generate in the editor.

We also went ahead and made the process of importing textures into the `GameManager` script more effecient by having the script automatically import the textures from the `Resources/Textures` path rather than manually importing them everytime a new scene is made with the GameManager script. Changes were also made to the `TextureRandomizer` Script to accommodate for the new texture importing method.

Seperately we've also started planning where to place specific **Generation Groups** on the Map, next update will contain a prototype version of the map with these Generation groups placed at specific locations (See Gen Map Below).

![GenMap](/Assets/Models/Map_Dev/floor1GenMap.png)
