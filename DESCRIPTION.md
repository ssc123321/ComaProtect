# Coma Protection

## 中文

只要再坚持一下，再坚持一下，我还有救的，只要再给我一点点时间，我能醒过来。

可惜原版不这么想。倒地之后，屏幕上的死亡倒计时并不会停：队友还在半山腰，你不知道他几秒能到，也不知道自己还能撑多久，只能盯着那条一直在走的进度条。

这个模组做的事很简单：**开启之后，死亡时间条不再随时间衰减，只有当你主动按 E 的时候才会衰减。**

所以等队友的时候可以安心等，想放弃的时候按一下 E，死得还是跟原版一样快。不用为了"想死一次"去关模组。

配置文件在 `BepInEx/config/abuf.comaprotect.cfg`，里面只有一项 `昏迷保护.启用`，默认就是开着的。改成 `false` 就回到原版，不用卸载。

只改你自己角色的计时器，不碰任何联网同步的数据；队友照样能把你扶起来，救援判定没动过。

---

## English

Just a little longer. Just a little longer — I can still make it, just give me a bit
more time and I'll wake up.

Vanilla PEAK doesn't agree. Once you are down, the death timer keeps ticking: your
teammate is still half a mountain away, and you have no idea whether they'll make it
— you can only watch that bar creep forward.

What this mod does is simple: **with it enabled, the death timer no longer drains over
time. It only drains when you hold E yourself.**

So you can wait for your teammate without a hidden countdown, and if you do want to
give up, press E — you die just as fast as before. No need to disable the mod just to
die once.

The config lives in `BepInEx/config/abuf.comaprotect.cfg` and has a single entry,
`昏迷保护.启用`, on by default. Set it to `false` for vanilla behaviour — no uninstall
needed.

It only touches your own character's timer and no networked data at all; teammates can
still revive you exactly as before.
