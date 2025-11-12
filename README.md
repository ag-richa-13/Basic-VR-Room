# Basic VR Room – Setup & Usage Guide

A step-by-step walkthrough for creating, configuring, and running the **Basic-VR-Room** sample project. The guide assumes you are starting **from scratch in Unity** and want to end up with a simple virtual-reality scene containing a room, a table, and a chair that are spawned automatically by the provided `FurnitureSpawner` script.

---
## 1. Prerequisites

1. **Unity Editor** – Version **2023.2 / 2023.3 LTS** **or** **6000.2.10f1** (the version used while developing this repo). Install via **Unity Hub**.
2. **XR-capable headset & runtime** – e.g. Meta Quest 2 (via Link / Air-Link), HTC Vive, Valve Index, Windows MR, etc.
3. **VR-ready PC** (if you are deploying to PC-VR) **or** Android SDK + OpenXR for standalone Quest build.
4. **Git** – to clone this repository (optional).

> The project targets **OpenXR** through Unity’s **XR Plugin Management** system and uses the **XR Interaction Toolkit (XRI)** together with the **Input System**.

---
## 2. Creating a New Project (if starting from scratch)

1. Open **Unity Hub ➜ Projects ➜ New Project**.
2. Select the template **"3D (URP) Core"** *or* **"VR URP"** if available.
3. Name the project `Basic-VR-Room` and choose a location.
4. Click **Create Project**.

> If you are cloning this repository, you can skip to *Section&nbsp;5*.

---
## 3. Enable XR & Input Packages

1. **Project Settings ➜ XR Plugin Management**
   - Click **Install XR Plugin Management** if prompted.
   - In the **PC** (Standalone) or **Android** tab, tick **OpenXR**.
   - Unity will prompt you to restart; accept.
2. **Project Settings ➜ XR Plug-in Management ➜ OpenXR ➜ Interaction Profiles**
   - Add the profiles that match your headset/controllers (e.g. *Oculus Touch Controller*, *HTC Vive Controller*, etc.).
3. **Window ➜ Package Manager** and ensure the following packages are installed:
   - **XR Interaction Toolkit** (v2.5+). Enable both Starter Assets when prompted.
   - **Input System** (if not already present).

---
## 4. Configure Input System

1. **Edit ➜ Project Settings ➜ Player ➜ Other Settings ➜ Active Input Handling** ⮕ set to **Both** (or **Input System (New)** only).
2. Import the `Assets/InputSystem_Actions.inputactions` file included in this repo. It already defines actions for locomotion, interaction, and UI.
3. In **Project Settings ➜ Input System Package ➜ Backend**, leave the default (`InputSettings` asset generated automatically).

---
## 5. Getting the Repository

```bash
# Option 1 – clone via git
$ git clone https://github.com/<your-user>/Basic-VR-Room.git

# Option 2 – download ZIP from GitHub and extract
```

Open the project in **Unity Hub ➜ Open** and select the extracted/cloned folder.

---
## 6. Scene & Room Setup

1. Open (or create) a scene under **`Assets/Scenes/`** (e.g. `BasicRoom.unity`).
2. **Create the room geometry**:
   - Add 4 **Cubes** for walls, 1 for floor, 1 for ceiling.
   - Group them under an empty **GameObject** named **`Room_Root`** located at world origin (0,0,0).
3. **Lighting**: keep the default *Directional Light* or set up baked lighting to taste.

---
## 7. Prefab Creation (Table & Chair)

1. Import or model your furniture meshes.
2. Drag each mesh into the Hierarchy, add **Collider** components (e.g. *Box Collider*).
3. Configure materials in **`Assets/Material/`** as desired and assign to the meshes.
4. Drag each configured object from Hierarchy into **`Assets/Prefab/`** to create **`Chair.prefab`** and **`Table.prefab`**.

---
## 8. Spawning Furniture via `FurnitureSpawner`

1. In **Hierarchy** add an empty GameObject named **`FurnitureSpawner`**.
2. Attach the script **`Assets/Scripts/FurnitureSpawner.cs`**.
3. In the **Inspector**:
   - **Chair Prefab** ➜ assign `Chair.prefab`.
   - **Table Prefab** ➜ assign `Table.prefab`.
   - **Room Root** ➜ drag `Room_Root` transform here.
   - Adjust **Chair/Table Position & Rotation** fields if necessary.

At **runtime**, the script automatically instantiates one chair and one table as children of `Room_Root` so they move together with the room if you reposition it.

---
## 9. Adding an XR Rig

1. From **Project ➜ Assets ➜ Samples ➜ XR Interaction Toolkit ➜ (version) ➜ Starter Assets**, drag **`XR Origin (VR)`** prefab into the scene.
2. Position the XR Origin at the center of the room, slightly above the floor.
3. Ensure colliders and *Locomotion System* (Teleportation / Continuous Move) are configured as you like.

---
## 10. Play & Test

1. Connect your VR headset (e.g. Quest via Link). Make sure **Oculus/SteamVR/OpenXR** runtime is running.
2. Press **Play** in Unity. You should spawn inside the virtual room and see the table and chair.
3. Use your controllers to move/teleport and interact if you added interaction components.

---
## 11. Build

1. **File ➜ Build Settings**.
2. Select your target platform (PC, Android). Click **Switch Platform** if necessary.
3. Ensure **XR Plugin Management** still lists OpenXR for the target.
4. Add your scene to **Scenes In Build**.
5. Click **Build** (or **Build & Run**).

---
## 12. Project Structure

```
Assets/
├─ Material/            # Optional material assets
├─ Prefab/              # Chair.prefab, Table.prefab
├─ Scenes/              # BasicRoom.unity (or your scene)
├─ Scripts/
│  └─ FurnitureSpawner.cs
├─ XR/                  # XR Plugin/Settings generated by Unity
├─ XRI/                 # XR Interaction Toolkit settings
└─ InputSystem_Actions.inputactions
Packages/               # Unity package manifest
```

---
## 13. Template & Packages Summary

* **Template Used**: *3D (URP) Core* with manual XR enablement (equivalent to Unity Hub’s *VR URP* template if selected).
* **Key Packages**:
  * `com.unity.inputsystem` – New Input System (already configured via `InputSystem_Actions.inputactions`).
  * `com.unity.xr.management` – XR Plugin Management.
  * `com.unity.xr.openxr` – OpenXR runtime support.
  * `com.unity.xr.interaction.toolkit` – XR Interaction Toolkit (provides XR rig, controllers, interaction system).

---
## 14. Troubleshooting

| Issue | Fix |
|-------|------|
| *Controllers not recognised* | Verify correct **Interaction Profile** is added under **OpenXR** settings. |
| *Scene is black* | Make sure a **Camera** exists (XR Origin contains one) and that *XR Plug-in Management* is enabled for the current platform. |
| *Input Actions not firing* | Confirm **Player Settings ➜ Active Input Handling** includes the *Input System* and that `InputSystem_Actions.inputactions` asset is referenced where needed. |

---
Enjoy building your first VR room! 🎉