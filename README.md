# Coma Protection

A small PEAK mod that stops the death timer while you are passed out.
Created by **ABUF**.

## What it does

When you are fully passed out (downed), vanilla PEAK slowly increases your death
timer until you die. With this mod the timer stays frozen, so you can wait for a
teammate to pick you up without a hidden countdown running.

**Giving up still works.** Hold the interact key (E) and the timer goes up at the
vanilla speed, so you can always choose to die — no need to disable the mod.

## Config

`BepInEx/config/abuf.comaprotect.cfg`

```ini
[昏迷保护]
启用 = true
```

| Key | Default | Meaning |
|---|---|---|
| `启用` (Enabled) | `true` | Freeze the death timer while passed out |

Set it to `false` to get vanilla behaviour without uninstalling.

## How it works

Vanilla `Character.UpdateVariablesFixed()` increases `data.deathTimer` in two ways:

- holding the interact key → `dt * 0.33` (voluntary give up)
- natural countdown (no carrier) → `dt / 60` or `dt / 10`

The mod restores the timer after the method runs, **except** while the interact
key is held, which is why giving up keeps working.

## Installation

1. Install **BepInEx 5** for PEAK.
2. Drop the `BepInEx` folder from the release zip into the game folder.
3. Launch the game once to generate the config.

## Building from source

Set two environment variables first (no local paths are stored in the repo):

```powershell
$env:PEAK_GAME_DIR     = "C:\path\to\PEAK"
$env:PEAK_BEPINEX_CORE = "C:\path\to\BepInEx\core"
./build.ps1
```

Output: `dist/ComaProtect-1.0.0.zip`

## License

MIT — see `LICENSE`.
