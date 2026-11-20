# 3D Endless Runner Demo

这是一个基于 Unity 引擎独立开发的 3D 无尽跑酷游戏 Demo

**[实机演示](https://www.bilibili.com/video/BV1UMs66xE2S/)**

##  技术
- **引擎与语言**：Unity 3D / C#
- **核心玩法**：基于 `CharacterController` 实现角色移动，包含自定义重力跳跃与平滑变道 (`Mathf.Lerp`)。
- **性能优化**：手写基于 `Queue` 的对象池 (Object Pool) 架构，对障碍物与金币进行动态回收与复用，解决频繁 Instantiate 导致的 GC 卡顿。
- **全局管理**：采用单例模式 (Singleton) 管理 `GameManager` 与 `AudioManager`。
- **物理交互**：基于 Trigger 的碰撞检测，实现吃金币加分与撞击扣血。
- **相机控制**：结合 `LateUpdate` 与 `Vector3.Lerp` 实现平滑的第三人称相机跟随。

