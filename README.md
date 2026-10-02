# CIA — Among Us Mod

CIA is an Among Us role mod built with C#, BepInEx, Reactor and MiraAPI.

## Current implementation

### Roles
- KILLER
- ALERTER
- CENSORER

All three are registered as MiraAPI Crewmate-side custom roles with the CIA black role color.

### KILLER — first functional system
- Uses MiraAPI's custom murder/RPC pipeline.
- Host setting: **Kill Cooldown: 10–30 seconds**.
- The round-start cooldown is loaded from the CIA role setting.
- The KILLER can only trigger the special interaction when both players are detected in the same room.
- Against an Impostor, the target is killed through the custom murder RPC with **no dead body**.
- Against a Crewmate, the target is rolled back toward its recorded position from roughly 5 seconds earlier and the KILLER is killed instead.
- A short position history is recorded locally for networked players so the rollback can use an actual previous position.

### ALERTER — pin and alarm system
- Uses MiraAPI's custom action-button system.
- The ALERTER gets a **CIA PIN** ability button.
- The nearest living player in ability range can be pinned.
- Pinning is local to the ALERTER, so the pinned identity is not broadcast to normal players.
- Host settings:
  - Pin Cooldown: 10–90 seconds
  - Pin Duration: 10–30 seconds
  - Alert Duration: 5–10 seconds
- When the pinned player performs an Impostor kill, the ALERTER receives the alarm sound and the alert state is active for the configured duration.

## Role settings

CIA role-specific host settings are exposed through MiraAPI role option groups:

### KILLER
- Kill Cooldown: 10–30 seconds

### ALERTER
- Pin Cooldown: 10–90 seconds
- Pin Duration: 10–30 seconds
- Alert Duration: 5–10 seconds

### CENSORER
- Max Put Censor: 1–3 sensors

## Planned / in progress

- Round-start CIA/vanilla role panel with X-to-close.
- CENSORER room sensor and player-list panel.
- Practice Mode dummy role assignment for CREWMATE, IMPOSTOR and all CIA roles.
- CIA role summary/statistics.
- Ghost information.
- Last-location information.
- Mobile-friendly UI/input adapter.

## Verification rule

A feature is considered implemented only after its API calls are verified against the target Among Us/MiraAPI version. Scaffolding and design notes are not treated as playable functionality.

## Role training

For CIA role training and reference material, use the **Chakabania** channel:

https://www.youtube.com/@chakabania

The same training destination is registered in the mod for the in-game help UI.
