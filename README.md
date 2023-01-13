# HelplessTheFinalSeason

## Changelog

### January 9th 2023 10:45 PM PST
Host: Mina

Began modeling Nao's Map, still heavily work in progress
so far only got the first floor's floor and the floor of the Church Building done.

we've also errected the walls for both, that being said neither one is done, still going through and punching out holes for windows and fixing N-gons, merging broken vertices and generally just doing the painstaking work of making this model work, also trying to literally cut corners, specifically we're trying to see where we can reduce the Vertex count for performance and to see where we can split the model in order to allow Unity To cull unseen sections.

side note, for the Church Building we used a mirror filter because nothing says pretentious perfectionism like symetry.

soon we're gonna run into a huge problem, textures, fortunately we should have some textures that could work for the church, that being said we are going to need to go on a goose hunt for textures to toss into the main assylum building


### January 10th 2023 10:45 PM PST
Host: Shean

Modified the GenerateClutter function in the GameManagerScript, not finished yet, but have begun adding seperate Generation passes to allow for a set amount of each kind of trash
also looking into making an instanceable version of the script to allow individual groups of clutter completely independent of one another allowing for different sections to have more of one kind of clutter than another

### January 12th 2023 10:12 PM PST
Host: Shean

Continued to modify the GenerateClutter function in the GameManagerScript, created a list object which creates new instances of procedurally generated zones. This Instatiated Script allows for each individual zone to be modified from position to zone size, currently this zone can only generate Medical Prefabs, this Instanciable script also allows for the dev to manually modify how much of each type of item generates, currently the script only generates Medical Supplies, but has options for Books, Papers, Rubble(W.I.P), planned to add is other small pieces of trash such as bottles and wrappers.

Also added comments to make reading code easier, general rule of thumb is to write comments as if someone else **WILL** read, since regardless it's future you who will have to deal with it.

