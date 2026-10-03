# CIA — Among Us Mod

CIA is an Among Us role mod built with C#, BepInEx, Reactor and MiraAPI.

## Roles

- **KILLER** — special attack logic with Impostor/Crewmate outcomes.
- **ALERTER** — pins one player and receives an alarm when that pinned player makes an Impostor kill.
- **CENSORER** — places room sensors and opens a live inside-player panel.

All three CIA roles are currently registered as Crewmate-side MiraAPI custom roles with the CIA black role color.

## Host settings

### KILLER
- Kill Cooldown: **10–30 seconds**

### ALERTER
- Pin Cooldown: **10–90 seconds**
- Pin Duration: **10–30 seconds**
- Alert Duration: **5–10 seconds**

### CENSORER
- Max Put Censor: **1–3 sensors**

## Implemented systems

### KILLER
- MiraAPI custom murder event/RPC pipeline.
- Round-start kill cooldown.
- Same-room interaction check.
- Impostor target: target is killed with no dead body.
- Crewmate target: target is moved toward a recorded position from about 5 seconds earlier, while KILLER dies.
- Short local position history for rollback.

### ALERTER
- CIA PIN custom action button.
- Nearest living-player targeting.
- Pin identity is kept local to the ALERTER.
- Configurable pin and alert timers.
- Alarm playback after a pinned Impostor makes a kill.

### CENSORER
- Sensor state with one-sensor-per-room enforcement.
- Maximum sensor count from the host setting.
- Reactor RPC scaffold for synchronizing sensor placement.
- Live `CENSOR SENSOR / INSIDE` panel.
- X closes the panel.
- Panel refreshes the player list while open.

### Round-start role panel
- Shows the local role after the vanilla intro ends.
- Supports vanilla and CIA/custom role names.
- Blocks movement while open.
- X closes the panel and returns control.

### Round statistics and last location
- Tracks round kills and deaths.
- Tracks each living player's latest detected room.
- A CIA INFO panel is available with **G** and shows role, alive/ghost state, round kills, deaths and last detected location.
- The information panel is local and closes with **G**.

### Practice Mode
- Assignment API supports:
  - CREWMATE
  - IMPOSTOR
  - KILLER
  - ALERTER
  - CENSORER
- A complete user-facing Practice Mode menu/freeplay workflow is not yet implemented.

### Training
The role training is the **Chakabania** (my) channel:

https://www.youtube.com/@chakabania

The same destination is registered by the mod for its training/help integration.

## Verification status

The repository contains build workflow configuration, but the target Among Us environment has not been run here. GitHub Actions/runtime results have not been verified yet.

Therefore, code marked as implemented means the system has been added to the repository; it does **not** mean every API call or multiplayer behavior has been proven in a live game.

## Remaining work

- Verify the exact target-version API signatures and resolve compile errors.
- Run a real Release build and inspect GitHub Actions output.
- Runtime-test multiplayer synchronization and role behavior.
- Finish a user-facing Practice Mode UI.
- Expand the information panel with additional verified ghost-only information when the target API is confirmed.
- Improve CENSORER placement to use a verified room-entrance interaction.
- Add a supported mobile input/UI adapter if the target loader permits it.

## Project rule

No feature is considered fully playable until its API and runtime behavior are verified against the target Among Us/MiraAPI version.
