# CIA Mod Design

## Round-start role panel
Every player receives a blocking role panel at round start:
- KILLER
- ALERTER
- CENSORER
- CREWMATE
- IMPOSTOR

The panel closes with X and normal gameplay resumes.

## KILLER
Host setting: Kill Cooldown (10–30 seconds).

- Target Impostor: target dies without a body; Killer survives.
- Target Crewmate: target is rolled back to their position from about 5 seconds earlier; Killer dies without a body.
- The special interaction should only activate when at least two players are in the same area/location.

## ALERTER
Host settings:
- Pin Cooldown: 10–90 seconds
- Pin Duration: 10–30 seconds
- Alert Duration: 5–10 seconds

Pin one player. If the pinned player is an Impostor and kills someone, an alarm is triggered from the victim/kill event. If the pinned player is a Crewmate, no alarm is triggered. Only CIA members know the pinned target.

## CENSORER
Host setting:
- Max Put Censor: 1–3 sensors

Place a sensor at a room entrance. The Censorer can open a panel listing players currently inside that room. Leaving players are removed from the list. Maximum one sensor per room.
