# HelplessTheFinalSeason

## Changelog

### January 9th 2023 10:45 PM PST
Began modeling Nao's Map, still heavily work in progress
so far only got the first floor's floor and the floor of the Church Building done.

we've also errected the walls for both, that being said neither one is done, still going through and punching out holes for windows and fixing N-gons, merging broken vertices and generally just doing the painstaking work of making this model work, also trying to literally cut corners, specifically we're trying to see where we can reduce the Vertex count for performance and to see where we can split the model in order to allow Unity To cull unseen sections.

side note, for the Church Building we used a mirror filter because nothing says pretentious perfectionism like symetry.

soon we're gonna run into a huge problem, textures, fortunately we should have some textures that could work for the church, that being said we are going to need to go on a goose hunt for textures to toss into the main assylum building

-Mina

### January 10th 2023 10:45 PM PST
Modified the GenerateClutter function in the GameManagerScript, not finished yet, but have begun adding seperate Generation passes to allow for a set amount of each kind of trash
also looking into making an instanceable version of the script to allow individual groups of clutter completely independent of one another allowing for different sections to have more of one kind of clutter than another