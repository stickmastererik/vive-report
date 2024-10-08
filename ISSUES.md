# Critical: *Map does not respawn after using report menu in a lobby* [#2](https://github.com/andrewpcvr/vive-report/issues/2)
This bug is with exiting the Report Menu. After pressing X to quit the menu, it does not reload the map.

## Quirks:
- If not in a lobby, this does not occur
- Only way to patch is to restart your game
- Collisions still occur, and you can hear players and sounds from footsteps.

## Solution Ideas:
[``octomonke``](https://github.com/andrewpcvr): Virtual leaderboard that appears on spectator screen, or manually reload the map when the report menu is closed

## Exploration
This method was found by ``octomonke`` and will figure out what map the player is in over the network
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

# Not Important: *Rebind button to a sandwich button* [#1](https://github.com/andrewpcvr/vive-report/issues/1)
Quality of life update to use a non-essential button to access the report menu.
Instead of pressing a secondary button, you can press the right sandwich button found on most SteamVR controllers.

## Solution Ideas:
[``octomonke``](https://github.com/andrewpcvr): Rebind using ``ControllerInputPoller``
