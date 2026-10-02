# CIA — Among Us Mod

CIA is an Among Us role mod built with C#, BepInEx, Reactor and MiraAPI.

## Current milestone

The repository now contains the first real MiraAPI custom-role definitions:

- KILLER
- ALERTER
- CENSORER

Each role is currently configured as a simple Crewmate-side custom role with a black CIA color. The vanilla kill/vent/sabotage systems are disabled for the prototype so we can build the CIA mechanics without unintended vanilla behavior.

## Planned role mechanics

### KILLER
- 10–30 second host-configurable kill cooldown.
- Attacking an Impostor kills the Impostor without a body.
- Attacking a Crewmate rolls the target back roughly 5 seconds and kills the KILLER without a body.
- The special interaction is restricted to players being in the same area.

### ALERTER
- Pin one player.
- If the pinned player is an Impostor and kills, an alarm is triggered.
- If the pinned player is a Crewmate, no alarm is triggered.
- Only CIA members know the pinned target.

### CENSORER
- Place a sensor at a room entrance.
- Open a panel listing players currently inside.
- Players leaving are removed from the list.
- Maximum one sensor per room, with a host-configurable total of 1–3 sensors.

## Next milestone

Connect role assignment and the round-start role reveal flow, then implement the first KILLER ability.
