# Coma Protection

## 中文

倒地之后，死亡倒计时还在悄悄往下走。
你不知道队友几秒后赶到，也不知道自己还能撑多久。
**——把倒计时按住。**

### 原版是怎么算的？

`Character.UpdateVariablesFixed()` 里，`deathTimer` 有两条增长途径：

| 情况 | 原版行为 |
|---|---|
| 无人来救（自然倒计时） | 每帧累加 `dt / 60`，某些情况下是 `dt / 10` |
| 按住 E 主动放弃 | 每帧累加 `dt × 0.33`，比自然快得多 |

所以只要倒地，计时器就一直在涨，直到倒地身亡。

### 这个模组做了什么？

在每帧结束时，把 `deathTimer` 复原成这一帧开始时的值：

| 情况 | 原版 | 装了本模组 |
|---|---|---|
| 无人来救 | 倒计时持续增长 | **停住不动** |
| 按住 E 放弃 | 快速死亡 | **仍然是快速死亡** |

关键在于「按住 E 时不还原」：想放弃随时都能放弃，不需要为了死一次去关模组。

### 配置

`BepInEx/config/abuf.comaprotect.cfg`

| 配置项 | 默认 | 说明 |
|---|---|---|
| `昏迷保护.启用` | `true` | 改成 `false` 即恢复原版倒计时，不用卸载模组 |

### 说明

- 纯客户端模组：只改本地角色的计时器，不修改任何网络同步数据
- 队友仍然能正常把你扶起来，救援/复活判定不受影响
- 多人游戏安全

---

## English

Once you are down, the death timer keeps ticking.
You don't know how far away your teammate is — or how long you have left.
**Hold the countdown.**

### How vanilla handles it

In `Character.UpdateVariablesFixed()`, `deathTimer` grows in two ways:

| Situation | Vanilla behaviour |
|---|---|
| Nobody picks you up (natural countdown) | `dt / 60` per frame, `dt / 10` in some cases |
| Holding E to give up | `dt × 0.33` per frame — much faster |

So while you are down, the timer keeps climbing until you die.

### What this mod does

At the end of every frame it restores `deathTimer` to the value it had when the
frame started:

| Situation | Vanilla | With this mod |
|---|---|---|
| Nobody picks you up | Timer keeps growing | **Frozen in place** |
| Holding E to give up | Fast death | **Still a fast death** |

The trick is that the timer is *not* restored while the interact key is held, so
you can always choose to die without disabling the mod.

### Config

`BepInEx/config/abuf.comaprotect.cfg`

| Key | Default | Meaning |
|---|---|---|
| `昏迷保护.启用` (Enabled) | `true` | Set to `false` for vanilla behaviour without uninstalling |

### Notes

- Client-side mod: only the local character's timer is touched, no network data is modified
- Teammates can still revive you normally; rescue and revive logic is untouched
- Multiplayer-safe
