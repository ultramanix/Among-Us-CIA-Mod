# CIA Feature Roadmap

## Core roles

- KILLER
- ALERTER
- CENSORER

## Practice Mode

Practice Mode is intended to support testing role behavior against dummy players. The test target list is deliberately shared with the core role system so future dummy-role assignment can support:

- CREWMATE
- IMPOSTOR
- KILLER
- ALERTER
- CENSORER

The actual dummy assignment hook will be implemented against the verified Among Us Practice Mode API instead of assuming that a dummy is identical to a normal networked player.

## Quality-of-life features

Planned CIA-specific QoL systems:

- Round-start role reveal panel with X-to-close.
- CIA role summary/statistics.
- Host settings grouped under CIA.
- Last-location information for supported CIA events.
- Ghost information appropriate to the player's role.
- Mobile-friendly interaction surfaces.

## Platform strategy

Role rules and game-state logic stay platform-neutral wherever possible. Input and UI adapters can then be implemented separately for keyboard/mouse and touch controls.

## Verification rule

A feature is considered implemented only after its API calls are verified against the target Among Us/MiraAPI version. Scaffolding and design notes are not treated as playable functionality.
