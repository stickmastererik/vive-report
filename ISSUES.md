# Critical: *Map does not respawn after using report menu in a lobby* [#2](https://github.com/andrewpcvr/vive-report/issues/2)
This bug is with exiting the Report Menu. After pressing X to quit the menu, it does not reload the map.

## Quirks:
- If not in a lobby, this does not occur
- Only way to patch is to restart your game
- Collisions still occur, and you can hear players and sounds from footsteps.

## Exploration Patches
### Will Work (Proven by other mods):
Providing a leaderboard that will pop up can be less detectable than the regular Oculus Report Menu. This may mean making a smaller dumbed-down ``BananaOS`` fork, and just using the leaderboard on there to report.

### In Experimentation
This method will figure out what map the player is in over the network.
```cs
string gamemode = PhotonNetworkController.Instance.currentJoinTrigger.networkZone;

if (gamemode == "forest")
{
    // We are in forest
}
if (gamemode == "city")
{
    // We are in city
}
if (gamemode == "canyons")
{
    // We are in canyons
}
if (gamemode == "mountains")
{
    // We are in mountains
}
if (gamemode == "beach")
{
    // We are in beach
}
if (gamemode == "sky")
{
    // We are in clouds
}
if (gamemode == "basement")
{
    // We are in basement
}
if (gamemode == "caves")
{
    // We are in caves
}
```
