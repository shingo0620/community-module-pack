# Events and Metas Observer zh-TW Translation Audit

Audit date: 2026-08-09

Scope: every one of the 73 keys in `Resources.resx`, compared with the pre-audit `Resources.zh-TW.resx`.

## Translation policy

1. Use a verified Guild Wars 2 Chinese client term before translating from English.
2. `cy-sp-howard/lang5` is the target environment. It converts the Chinese client text to Traditional Chinese through `ref/jianfan.json` and Taiwan-oriented overrides in `ref/add.json`; it is **not** a complete standalone dump of every game string. Therefore, verified Simplified Chinese client/community-resource terms below are converted with lang5's rules.
3. World bosses, meta events, event chains, and named encounters use `中文名稱（English official name）`. The English portion preserves the original `Resources.resx` value (for example, `Sandstorm`, not `Sandstorm!`). Ordinary UI remains natural Traditional Chinese only.
4. A related boss, colloquial name, achievement, or event objective must not replace the resource key's own event/meta identity. `Evolved Jungle Wurm` is not renamed to `Triple Trouble`; `Dangerous Prey` is not renamed to its final boss.

The same rule explains why the known in-game string `Juvenile Arctodus → 幼齡短面熊` is treated as authoritative over a plausible literal translation. It is not a key in this resource file.

## Results

| Result | Count | Notes |
| --- | ---: | --- |
| Audited keys | 73 | Complete `Resources.resx` key set. |
| Resource values changed | 45 | 43 verified terminology/bilingual updates; 2 provisional bilingual renderings retained pending direct client confirmation. |
| Verified — no semantic change | 28 | General UI, cycle labels, categories, and already-correct non-proper-noun values. |
| Needs verification | 2 | `Night Bosses` and `Advancing on the Blighting Towers`; see their rows. |

## Key-by-key audit

`Prior zh-TW` is the value in the committed file before this audit. `Final zh-TW` is the audited result.

| Category | English key / name | Prior zh-TW | Final zh-TW | Evidence / reason |
| --- | --- | --- | --- | --- |
| UI | All Events | 所有事件 | 所有事件 | Verified — natural UI. |
| UI | Alphabetical | 依名稱排序 | 依名稱排序 | Verified — natural UI. |
| UI | Events and Metas | 事件與大型事件 | 事件與大型事件 | Verified — natural UI. |
| UI | Hidden Events | 隱藏事件 | 隱藏事件 | Verified — natural UI. |
| UI | Next Up | 即將開始 | 即將開始 | Verified — natural UI. |
| UI | Enable Notifications | 啟用通知 | 啟用通知 | Verified — natural UI. |
| UI | Mute Notifications | 通知靜音 | 通知靜音 | Verified — natural UI. |
| UI | Event Categories | 事件分類 | 事件分類 | Verified — natural UI. |
| UI | Event Search | 搜尋事件 | 搜尋事件 | Verified — natural UI. |
| UI | Read about this event on the wiki. | 在 Wiki 查看此事件。 | 在 Wiki 查看此事件。 | Verified — natural UI. |
| UI | Nearby waypoint: {0} | 附近傳送點：{0} | 附近傳送點：{0} | Verified — `{0}` retained. |
| UI | Failed to copy waypoint to clipboard. Try again. | 無法將傳送點複製到剪貼簿，請再試一次。 | 無法將傳送點複製到剪貼簿，請再試一次。 | Verified — natural UI. |
| UI | Copied waypoint to clipboard! | 已將傳送點複製到剪貼簿！ | 已將傳送點複製到剪貼簿！ | Verified — natural UI. |
| UI | Click to toggle tracking for this event. | 點擊以切換此事件的追蹤狀態。 | 點擊以切換此事件的追蹤狀態。 | Verified — natural UI. |
| UI | Starts in {0} | {0} 後開始 | {0} 後開始 | Verified — `{0}` retained. |
| UI | Upcoming Event Times: | 接下來的事件時間： | 接下來的事件時間： | Verified — natural UI. |
| UI | Notification_Tooltip | 按左鍵複製傳送點。<br>按右鍵關閉通知。 | 按左鍵複製傳送點。<br>按右鍵關閉通知。 | Verified — newline retained as `&#xA;` in resx. |
| UI | Failed to load metas from events.json! | 無法從 events.json 載入大型事件！ | 無法從 events.json 載入大型事件！ | Verified — natural UI. |
| Cycle / category | Day-Night Cycle | 日夜循環 | 日夜循環 | Verified — non-proper-noun category. |
| Cycle / category | Day | 白天 | 白天 | Verified — non-proper-noun event. |
| Cycle / category | Night | 夜晚 | 夜晚 | Verified — non-proper-noun event. |
| Cycle / category | Dawn | 黎明 | 黎明 | Verified — non-proper-noun event. |
| Cycle / category | Dusk | 黃昏 | 黃昏 | Verified — non-proper-noun event. |
| Cycle / category | Server Reset | 伺服器重置 | 伺服器重置 | Verified — non-proper-noun event. |
| Cycle / category | Other | 其他 | 其他 | Verified — category label. |
| Cycle / category | Group Event | 團隊事件 | 團隊事件 | Verified — Chinese GW2 event-type terminology. |
| Group event | Ley-Line Anomaly (Timberline Falls) | 魔徑異常體（林線瀑布） | 魔徑異常體（林線瀑布）（Ley-Line Anomaly (Timberline Falls)） | Chinese GW2 resources use `魔径异常体`; map name is `林线瀑布`; lang5 conversion + bilingual policy. |
| Group event | Ley-Line Anomaly (Iron Marches) | 魔徑異常體（鋼鐵平原） | 魔徑異常體（鋼鐵平原）（Ley-Line Anomaly (Iron Marches)） | Chinese GW2 resources use `魔径异常体`; map name is `钢铁平原`; lang5 conversion + bilingual policy. |
| Group event | Ley-Line Anomaly (Gendarran Fields) | 魔徑異常體（甘達拉戰區） | 魔徑異常體（甘達拉戰區）（Ley-Line Anomaly (Gendarran Fields)） | Chinese GW2 resources use `魔径异常体`; map name is `甘达拉战区`; lang5 conversion + bilingual policy. |
| World boss category | World Bosses | 世界首領 | 世界BOSS | Chinese GW2 timer/community-client terminology is `世界BOSS`; this is the established label, not a literal UI translation. |
| World boss | Admiral Taidha Covington | 上將泰達·科文頓 | 上將泰達·科文頓（Admiral Taidha Covington） | Verified Chinese name + bilingual policy. |
| World boss | Claw of Jormag | 卓瑪之爪 | 卓瑪之爪（Claw of Jormag） | Verified Chinese GW2 resource `卓玛之爪`; lang5 conversion + bilingual policy. |
| World boss | Drakkar, the Ice Dragon's Champion | 冰龍首領德拉克 | 冰霜巨龍首領：德拉克（Drakkar, the Ice Dragon's Champion） | Verified client/community name `冰霜巨龙首领：德拉克`; restores `冰霜` and title punctuation. |
| World boss | Evolved Jungle Wurm | 進化叢林地蟲 | 進化叢林地蟲（Evolved Jungle Wurm） | Verified Chinese GW2 name. Keep the boss identity; do not substitute the colloquial `Triple Trouble`. |
| World boss | Fire Elemental | 火元素 | 火元素（Fire Elemental） | Verified Chinese GW2 name + bilingual policy. |
| World boss | Great Jungle Wurm | 巨型叢林地蟲 | 巨型叢林地蟲（Great Jungle Wurm） | Verified Chinese GW2 name + bilingual policy. |
| World boss | Inquest Golem Mark II | 審訊團魔像二型 | 審訊團魔像馬克II型（Inquest Golem Mark II） | Verified Chinese client resource `审讯团魔像马克II型`; `二型` was not the displayed proper name. |
| World boss | Karka Queen | 喀殼蟲女王 | 喀殼蟲女王（Karka Queen） | Verified Chinese GW2 name + bilingual policy. |
| World boss | Megadestroyer | 超能毀滅者 | 超能毀滅者（Megadestroyer） | Verified Chinese GW2 name + bilingual policy. |
| World boss | Modniir Ulgoth | 莫迪爾沃爾格斯 | 莫迪爾沃爾格斯（Modniir Ulgoth） | Verified Chinese GW2 name + bilingual policy. |
| World boss | Shadow Behemoth | 暗影巨獸 | 暗影巨獸（Shadow Behemoth） | Verified Chinese GW2 name + bilingual policy. |
| World boss | The Shatterer | 碎裂巨獸 | 碎裂巨獸（The Shatterer） | Verified Chinese GW2 name + bilingual policy. |
| World boss | Svanir Shaman Chief | 斯瓦尼亞薩滿酋長 | 斯瓦尼亞薩滿酋長（Svanir Shaman Chief） | Verified Chinese GW2 name + bilingual policy. |
| World boss | Tequatl the Sunless | 無日者泰瑞亞特 | 陰鬼"吞噬托"（Tequatl the Sunless） | Verified Chinese client name `阴鬼"吞噬托"`; lang5 conversion preserves the quotation marks. Replaces an invented transliteration. |
| Meta category | Meta Event | 大型事件 | 大型事件 | Verified — established Chinese GW2 category. |
| Meta event | Crash Site | 墜機地點 | 墜毀點（Crash Site） | Verified Chinese meta title `坠毁点`; lang5 conversion + bilingual policy. |
| Meta event | Sandstorm | 沙塵暴 | 沙塵暴！（Sandstorm） | Verified Chinese meta title `沙尘暴！`; English is intentionally preserved exactly as the `Resources.resx` value. |
| Meta event | Securing Verdant Brink | 確保蒼翠邊界安全 | 防守蒼翠邊界（Securing Verdant Brink） | Verified Chinese meta title `防守苍翠边界`; replaces literal prose. |
| Meta event | Night and the Enemy | 敵軍夜襲 | 敵軍夜襲（Night and the Enemy） | Verified Chinese meta title `敌军夜袭`; bilingual policy. |
| Meta event stage | Night Bosses | 夜間首領 | 夜間首領（Night Bosses） | **Needs verification.** `events.json` uses this as a stage within `Night and the Enemy`; no direct client display string was retrieved. The existing generic Chinese label is retained provisionally and English remains visible. |
| Meta event | Trial by Fire | 火焰試煉 | 火焰試煉（Trial by Fire） | Verified Chinese meta title `火焰试炼`; bilingual policy. |
| Meta event | Battle in Tarir | 塔瑞爾之戰 | 塔瑞爾之戰（Battle in Tarir） | Verified Chinese meta title `塔瑞尔之战`; bilingual policy. |
| Meta event | Defending Tarir | 防守塔瑞爾 | 保衛塔瑞爾（Defending Tarir） | Verified Chinese meta title `保卫塔瑞尔`; corrects the event-chain terminology. |
| Meta event / encounter | Chak Gerent | 查克蟲王 | 查克蟲王（Chak Gerent） | Verified Chinese GW2 boss name; bilingual policy. |
| Meta event phase | Advancing on the Blighting Towers | 向枯萎之塔推進 | 向枯萎之塔推進（Advancing on the Blighting Towers） | **Needs verification.** English wiki identifies the phase, but no direct Chinese-client title was retrieved. Existing wording is retained provisionally; it must not be broadened to `巨龍突破` because the resource is a phase, not the whole Dragon's Stand meta. |
| Meta event | Casino Blitz | 俱樂部閃電戰 | 賭場閃電戰（Casino Blitz） | Verified Chinese meta title `赌场闪电战`; `俱樂部` was a false literal sense. |
| Named encounter | Choya Pinata | 丘牙獸彩罐 | 丘牙獸彩罐（Choya Piñata） | Verified Chinese GW2 encounter name + bilingual policy. |
| Meta event | The Search for Buried Treasure | 尋找埋藏的寶藏 | 尋找埋藏的寶藏（The Search for Buried Treasure） | Verified Chinese meta title `寻找埋藏的宝藏`; retain `尋找` because `埋藏的寶藏` alone is a different interactable/loot name. |
| Meta event | The Path to Ascension | 晉升之路 | 晉升之路（The Path to Ascension） | Verified Chinese meta title `晋升之路`; bilingual policy. |
| Meta event | Junundu Rising | 巨嘴蟲崛起 | 巨努多崛起（Junundu Rising） | Verified Chinese meta title `巨努多崛起`; `Junundu` is the game proper noun, not a generic `巨嘴蟲`. |
| Meta event | Maws of Torment | 苦痛之口 | 磨難血口（Maws of Torment） | Verified Chinese meta title `磨难血口`; replaces direct translation. |
| Meta event | Forged with Fire | 烈火鍛造 | 烈焰塑形（Forged with Fire） | Verified Chinese meta title `烈焰塑形`; do not replace it with the related faction `塑形軍隊`. |
| Meta event | Serpents' Ire | 群蛇之怒 | 巨蛇之怒（Serpents' Ire） | Verified Chinese meta title `巨蛇之怒`; do not replace it with the final encounter `烙印被遺忘者狂徒`. |
| Meta event | Palawadan, Jewel of Istan | 帕拉瓦丹，伊斯坦之珠 | 帕拉瓦之城，伊斯坦之寶（Palawadan, Jewel of Istan） | Verified Chinese meta/location name `帕拉瓦之城，伊斯坦之宝`; restores the game place name. |
| Meta event | Dangerous Prey | 危險獵物 | 危險掠食者（Dangerous Prey） | Verified Chinese meta title `危险掠食者`; do not replace it with the final boss `死亡烙印碎裂巨獸`. |
| Meta event | Thunderhead Keep | 雷雲要塞 | 雷雲要塞（Thunderhead Keep） | Verified Chinese GW2 location/meta title `雷云要塞`; bilingual policy. |
| Meta event | The Oil Floes | 油流浮冰 | 油料浮冰（The Oil Floes） | Verified Chinese GW2 title `油料浮冰`; replaces an invented word order. |
| Meta event | A Concert for the Ages | 傳世音樂會 | 老年音樂會（A Concert for the Ages） | Verified Chinese GW2 meta title `老年音乐会`; replaces the invented `金屬軍團演唱會` association. |
| Meta event | Ceremony of the Sacred Flame | 聖火儀式 | 神聖烈焰儀式（Ceremony of the Sacred Flame） | Verified Chinese GW2 meta title `神圣烈焰仪式`; restores the full proper name. |
| Meta event | The Haunting of Doomlore Shrine | 毀滅傳說神殿鬧鬼事件 | 鬧鬼的厄運傳說聖壇（The Haunting of Doomlore Shrine） | Verified Chinese GW2 meta title `闹鬼的厄运传说圣坛`; corrects both the place name and word order. |
| Meta event | The Ooze Pit Trials | 軟泥坑試煉 | 軟泥鬥坑試煉（The Ooze Pit Trials） | Verified Chinese GW2 meta title `软泥斗坑试炼`; restores `鬥坑`. |
| Meta event | Storms of Winter | 冬日風暴 | 冬日風暴（Storms of Winter） | Verified Chinese GW2 meta title `冬日风暴`; bilingual policy. |
| UI category | Watched Events | 已追蹤事件 | 已追蹤事件 | Verified — natural UI. |

## Source notes

- **lang5 target conversion:** [`cy-sp-howard/lang5`](https://github.com/cy-sp-howard/lang5), especially `ref/jianfan.json` and `ref/add.json`.
- **Chinese client terminology and map/event identity:** the Chinese GW2 resource corpus mirrored by [激戰 2 中文維基](https://gw2.huijiwiki.com/) and its pages for `陰鬼"吞噬托"`, `防守蒼翠邊界`, `烈焰塑形`, `巨蛇之怒`, `危險掠食者`, and the Grothmar Valley metas.
- **English identity only:** [`Events Module/ref/events.json`](../ref/events.json) and the linked English GW2 Wiki pages. They determine the exact resource semantic and prevent colloquial/encounter substitutions.
- **Map localization support:** the official [Guild Wars 2 API localization documentation](https://wiki.guildwars2.com/wiki/API:2) confirms `lang=zh`; map names used here correspond to the Chinese API/client forms and are then transformed by lang5.

## Remaining uncertainties

1. **Night Bosses** — an internal schedule stage under `Night and the Enemy`, not a client-facing proper title located in the available sources.
2. **Advancing on the Blighting Towers** — an event-chain phase within Dragon's Stand. The English identity is verified, but a direct Chinese client title was not retrieved. Do not replace it with the broader `巨龍突破` meta name without a client screenshot/string.
