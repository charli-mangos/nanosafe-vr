# NanoSafe VR

Virtual-reality training on the **safe use of nanoproducts** in the stone, construction and industrial sectors.
Trainees walk through realistic work situations, choose the right personal protective equipment (PPE),
prepare the work area and answer short quizzes about the risks of handling nanomaterials.

NanoSafe was developed in 2022 at CTM (Centro Tecnológico del Mármol, Piedra y Materiales, Spain) as
part of an Erasmus+ project carried out by a European consortium.

It is published with CTM's permission.

> **EU funding.** Co-funded by the Erasmus+ Programme of the European Union. The European Commission's
> support for this work does not constitute an endorsement of its contents, which reflect the views only of
> the authors, and the Commission cannot be held responsible for any use which may be made of the
> information contained therein.

## Features

- Ten training situations, each made of several missions (PPE selection, area preparation, the task itself,
  clean-up) with multiple-choice and multiple-selection quizzes.
- A mistake counter: after too many errors the trainee is sent back to the manual or the trainer.
- Teleport locomotion, two-hand grabbing and object highlighting with the XR Interaction Toolkit.
- Five languages loaded at runtime from `Assets/Resources/Lang/*.txt`: English, Spanish, German,
  Greek and Italian.

| # | Situation |
|---|-----------|
| 1 | Use of a sawing machine with water cooling to reduce dust |
| 2 | Application depending on the nanoproduct at a factory |
| 3 | Pouring nanomaterial powder into a liquid matrix to create a mixture |
| 4 | Nanomaterial applied with a spray gun on a stone surface |
| 5 | Nanomaterial fixed in a solid matrix that is being drilled |
| 6 | Application of different products in a factory (part II) |
| 7 | Dust–air mixtures in a factory |
| 8 | Nano-waste management and environmental protection |
| 9 | Nanomaterial applied as an aerosol |
| 10 | Waste cleaning or disposal after working hours |

Scenes live in `Assets/Scenes`: `Menu`, `Situation_1` … `Situation_10`, plus the shared environments
`Scenario_CONSTRUCTION`, `Scenario_POOL` and `Scenario_WAREHOUSE`. The build settings include `Menu` and
situations 1, 2, 4, 6, 9 and 10.

## Tech stack

- **Unity 2019.4.31f1** (LTS) with the Universal Render Pipeline 7.7.1.
- **Legacy built-in XR** with the Oculus (Standalone and Android/Quest) and OpenVR SDKs.
- **XR Interaction Toolkit 2.0.1**, XR Management 4.2.1 and Legacy Input Helpers.
- TextMesh Pro, Timeline and NavMesh (non-player characters follow paths in `Assets/Navigation`).
- C# gameplay code in `Assets/Scripts`: game and mission flow, quizzes, object selection, translation,
  hand and locomotion controllers.

> Unity 2019.4.31f1 is affected by [CVE-2025-59489](https://unity.com/security/sept-2025-01).
> Rebuild with **2019.4.41f1** or later before distributing any player build.

## Opening the project

1. Install **Unity 2019.4.31f1** (or 2019.4.41f1 to include the security fix) with Android Build Support
   if you target Meta Quest.
2. Clone the repository (it uses [Git LFS](https://git-lfs.com) for binary assets) and open the folder in
   Unity Hub.
3. **Third-party assets are not included.** Their licences do not allow redistribution, so scenes open with
   missing meshes, materials, audio and hand models. To restore them, get your own copies:

   | Missing content | Where to get it |
   |---|---|
   | Unity Standard Assets (particle systems, e.g. the dust storm) | Unity Asset Store: *Standard Assets (for Unity 2018.4)* |
   | Skyboxes | Unity Asset Store: *SkySerie Freebie* (or any skybox) |
   | Grass and flower textures | Unity Asset Store: a grass and flowers pack |
   | Construction worker animations and props | Unity Asset Store: a construction worker pack |
   | Worker character and animations | [Mixamo](https://www.mixamo.com) (character "Ch17" and the idle, walk, talk and pick-up animations) |
   | Hand and controller models | Oculus Integration or the XR Interaction Toolkit samples |
   | PPE and props (masks, respirator, boots, gloves, garden tools, bins…) | [CGTrader](https://www.cgtrader.com) and similar marketplaces |
   | Ambient audio | Any royalty-free sound library |

   Then reassign the missing references in the scenes listed above.
4. Open `Assets/Scenes/Menu.unity` and press Play with a headset connected, or build for Android (Quest)
   or Windows (Oculus Rift or SteamVR).

## Project layout

```
Assets/
  Scripts/      gameplay, quizzes, selection, translation, XR controllers
  Scenes/       menu, situations and shared scenarios
  Resources/    language files (Lang/*.txt)
  Prefabs/      the VR player, quizzes, signals and the team's own environment models
  Navigation/   NavMesh data per situation
  Animation/    door, car and signal animations
  Images/       UI sprites, PPE and hazard pictograms
ProjectSettings/, Packages/   Unity configuration
```

## My role

I was the lead developer of NanoSafe at CTM in 2022. I wrote all of the application code (C#): the VR player
and hand interactions, the PPE-selection and area-preparation missions, the quizzes and scoring, the scene flow
across the ten situations, the menus and the localisation system (five languages), and I assembled the
training scenes.

## Credits

- Development: Carlos Martínez (CTM).
- 3D environments and models: Eduardo Martínez García ([@edmarga](https://github.com/edmarga)).
- Developed at CTM within the NanoSafe Erasmus+ consortium. The partner organisations' logos are shown in the main menu.
- Third-party components that are still included are listed in [THIRD_PARTY_NOTICES.md](THIRD_PARTY_NOTICES.md).

## License

**Pending.** No licence has been granted yet: until one is added, all rights are reserved. The choice
depends on CTM, as the beneficiary of the Erasmus+ project.

## Security

See [SECURITY.md](SECURITY.md).
