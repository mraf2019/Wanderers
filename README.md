![image](titlepage.png)
# Enlighter

# Getting Started
We use `Unity Hub` and `Unity 2022.3.4f1` to develop our game.

Download Unity LTS Release version 2022.3.4f1 from https://unity.com/releases/editor/qa/lts-releases. This will automatically download Unity Hub for you. Remember to check you have included the Android Build Support platform while installing.

Open Unity Hub, in the Project panel, click the small arrow beside the `Open` button in the top right corner and choose `Add project from disk`. Then choose the file of our project and click `Add Project` in the bottom right corner. Wait for Unity to complete setup and you can see Unity opening our project.

![image](UnityHub.png)

You can directly play our game in the unity editor by clicking the `play` button right below the top bar.

If you want to build an .exe file to play this game on `Windows`, `Mac`, or `Linux`, click `file` -> `Build Settings` -> `Build` and choose where you want to put your file.

![image](HowToBuild.png)

If you want to build and play on your phone, for `Android`, switch platform from `Windows` to `Android`, click build, and choose file path.

For `iOS`, switch platform from `Windows` to `iOS`, click build, and choose file path.


# Model and Engine
## story map
![image](story_map.png)

## engine architecture
![image](engine_architecture.png)
# In Game

### Card handler

- Stores the list of cards collection
- Fetches the information of one card
- processes the chartlets and images of the given card

### Deck & action handler

- Handles the card deck so as to ensure only one card is selected
- Checks the player is in a right condition when releasing a card
- Calculates and settles account of a selected card with regard to the information from the card handler

### Player Status handler

- Records the player's health, card list, various status, currency and location
- Connects to the UI elements to ensure displaying correctly
- Handles the player's health, status (speed up/down, invincible), currency, movement (speed and location) and animation while changes happen
- Fetches user info and character info from the host 

### Skill handler

- Controls the cooldown and effect of the skill
- Checks the player is in a right condition when releasing the skill

### Loot handler

- Randomly generates loots on the map
- Changes the player's deck while collecting the loot

### Trading Controller

- Randomly generates three cards for players to purchase 
- Controls purchasing system
- connects with player's currency

### Region Controller

- Randomly shuts down regions when the regulated time is coming
- Produces damage to the player if one is still in such region

### Minimap and Location Handler

- Shows the location of player on the entire map

### Round Status handler

- Records the rank of the player given the time of death (1st if never fails)

# Rooms Related

### User info handler

- Uploads username to the host for the game scene to fetch
- Checks no prior redundant username is given

### Room info handler

- Generates a list of player in the same room
- Creates a room in terms of a serial number if not even exists
- Player joins a room if already exists

### Character info handler

- Records which character the player has chosen for later uses

# Result & Rankings

### Result handler

- Produces the result given rank in the game part


# APIs and Controller





### Endpoint
##### `GET /players/{playerId}/skills`

Retrieves the skills held by a specific player.

**Path Parameters**
| Parameter  | Type   | Description                       |
| ---------- | ------ | --------------------------------- |
| `playerId` | string | The unique identifier of a player |

**Response Codes**
| Code                      | Description              |
| ------------------------- | ------------------------ |
| `200 OK`                  | Success                  |
| `400 Bad Request`         | Invalid parameters       |
| `503 Service Unavailable` | Server fails to get data |

**Response**
```json
{
  "playerId": "string",
  "skills": [
    {
      "name": "string",
      "description": "string",
      "attack": boolean,
      "healthChange": number
    },
    ...
  ]
}
```
- `playerId` (string): The unique identifier of the player.
- `skills` (array): An array of skill objects representing the skills held by the player.
- `name` (string): The name of the skill.
- `description` (string): A description of the skill.
- `attack` (boolean): Indicates whether the skill is an attack skill.
- `healthChange` (number): The amount of health change caused by the skill.


### Endpoint
##### `GET /players/{playerId}/CharacterStatus`

Retrieves the status of a specific online player.

**Path Parameters**
| Parameter  | Type   | Description                       |
| ---------- | ------ | --------------------------------- |
| `playerId` | string | The unique identifier of a player |

**Response Codes**
| Code                      | Description              |
| ------------------------- | ------------------------ |
| `200 OK`                  | Success                  |
| `400 Bad Request`         | Invalid parameters       |
| `503 Service Unavailable` | Server fails to get data |

**Response**
```json
{
  "playerId": "string",
  "maxHealth": int,
  "initialSpeed": float,
  "speed": float,
  "currency": int,
  "cards": [
    {
      "id": "string",
      "rank": "string",
      "category": "string",
      "visible": boolean,
      "inUse": boolean
    },
    ...
  ],
  "mySkill": {
    "name": "string",
    "description": "string",
    "attack": boolean,
    "healthChange": number
  },
  "isInvincible": boolean,
  "isSpeedUp": boolean,
  "isSpeedDown": boolean
}
```
- `playerId` (string): The unique identifier of the online player.
- `maxHealth` (int): The maximum health points of the player.
- `initialSpeed` (float): The initial movement speed of the player.
- `speed` (float): The current movement speed of the player.
- `currency` (int): The in-game currency of the player.
- `cards` (array): An array of card objects representing the cards held by the player.
- `id` (string): The unique identifier of the card.
- `category` (string): The category of the card (e.g., "regular", "profession", "character").
- `rank` (string): The rank of the card (e.g., "white", "blue", "orange").
- `visible` (boolean): Indicates whether the card is visible to other players.
- `inUse` (boolean): Whether the card is in use.
- `mySkill` (object): Skill information associated with the player.
- `name` (string): The name of the skill.
- `description` (string): A description of the skill.
- `attack` (boolean): Indicates whether the skill is an attack skill.
- `healthChange` (number): The amount of health change caused by the skill.
- `isInvincible` (boolean): Indicates whether the player is currently invincible.
- `isSpeedUp` (boolean): Indicates whether the player's speed is currently increased.
- `isSpeedDown` (boolean): Indicates whether the player's speed is currently decreased.

### Endpoint
##### `GET /players/{playerId}/loot`

Retrieves the loot collected by a specific player.

**Path Parameters**
| Parameter  | Type   | Description                       |
| ---------- | ------ | --------------------------------- |
| `playerId` | string | The unique identifier of a player |

**Response Codes**
| Code                      | Description              |
| ------------------------- | ------------------------ |
| `200 OK`                  | Success                  |
| `400 Bad Request`         | Invalid parameters       |
| `503 Service Unavailable` | Server fails to get data |

**Response**
```json
{
  "playerId": "string",
  "loot": [
    {
      "id": "string",
      "rank": "string",
      "category": "string",
      "visible": boolean,
      "inUse": boolean
    },
    ...
  ]
}
```
- `playerId` (string): The unique identifier of the player.
- `loot` (array): An array of loot objects representing the collected items.
- `id` (string): The unique identifier of the item.
- `category` (string): The category of the item (e.g., "weapon", "armor", "consumable").
- `rank` (string): The rank of the item (e.g., "common", "rare", "legendary").
- `visible` (boolean): Indicates whether the item is visible to other players.
- `inUse` (boolean): Whether the item is currently in use.


### Endpoint
##### `GET /players/{playerId}/cards`

Retrieves the cards held by a specific player.

**Path Parameters**
| Parameter  | Type   | Description                       |
| ---------- | ------ | --------------------------------- |
| `playerId` | string | The unique identifier of a player |

**Response Codes**
| Code                      | Description              |
| ------------------------- | ------------------------ |
| `200 OK`                  | Success                  |
| `400 Bad Request`         | Invalid parameters       |
| `503 Service Unavailable` | Server fails to get data |

**Response**
```json
{
  "playerId": "string",
  "cards": [
    {
      "id": "string",
      "rank": "string",
      "category": "string",
      "visible": boolean,
      "inUse": boolean
    },
    ...
  ]
}
```
- `playerId` (string): The unique identifier of the player.
- `cards` (array): An array of card objects representing the cards held by the player.
- `id` (string): The unique identifier of the card.
- `category` (string): The category of the card (e.g., "regular", "profession", "character").
- `rank` (string): The rank of the card (e.g., "white", "blue", "orange").
- `visible` (boolean): Indicates whether the card is visible to other players.
- `inUse` (boolean): Whether the card is currently in use.



## Third-Party SDKs

None

# View UI/UX

### Main Menu
Play button is the entry for players who want to start a new game. Tutorial button is designed for beginners as guidance.
![image](View_UIUX/1.png)
First you can choose your character.
![image](View_UIUX/100.png)
Then host a game or join a game.
![image](View_UIUX/2.png)
![image](View_UIUX/3.png)
![image](View_UIUX/4.png)
Only the room owner can start the game. Start the game when all players enter the room.
![image](View_UIUX/200.png)
This is the UI after entering the game. The health bar is on the top the screen so that players can monitor their status easily. You can walk around, collect loot and attack other enemies like in the tutorial demonstrated in the next section.
![image](View_UIUX/400.png)
Since there is limited resources available (will be refreshed frequently), you can find the merchant can buy the cards you want.
![image](View_UIUX/600.png)
![image](View_UIUX/700.png)
![image](View_UIUX/800.png)
After some time, regions will be shut down gradually. Staying in the shut down region will end up in great amount of constant health decrease.
![image](View_UIUX/500.png)
You can use the cards collected or bought from the merchant to heal yourself.
![image](View_UIUX/900.png)
![image](View_UIUX/1000.png)
If you die or live till the end when others die, you will entered the result page that shows your ranking.
![image](View_UIUX/300.png)

### Tutorial
According to the usability test, we add some operation instructions to guide beginners so that they will not be confused.
First choose your character.
![image](View_UIUX/5.png)
Then move around by dragging the joystick.
![image](View_UIUX/7.png)
Resourses on the map can be picked up, which usually represents a card.
![image](View_UIUX/8.png)
Attack the enemy using cards and skills.
![image](View_UIUX/9.png)
Kill the enemy and pick up loot.
![image](View_UIUX/10.png)
Attacked by enemy. According to the usability test, both player's and the enemy's character status are clearly presented as health bar(on the top of the screen and above the enemy's head).
![image](View_UIUX/11.png)
There have been complaints that character skill is hard to notice. For cases like this, users can press menu button and look for illustration on the interface. Players are also able to exit the game whenever they want through this menu.
![image](View_UIUX/12.png)
![image](View_UIUX/13.png)
Move to another region and kill the last enemy.
![image](View_UIUX/14.png)
Win the game and reach to the result page of the game.
![image](View_UIUX/16.png)



# Team Roster

| Name        | GitHub Username                                | Design            | Programming |
| ----------- | -------------------------------------------    | ----------------- | ----------- |
| Qi Lei      | [LeiQi7](https://github.com/LeiQi7)            | System Design     | Front end   |
| Lan Wang    | [yexiaosu](https://github.com/yexiaosu)        | Role Design       | Back end    |
| Zefang Wei  | [mraf2019](https://github.com/mraf2019)        | Background Design | Front end   |
| Yiwei Zhang | [Sunnyvale7](https://github.com/Sunnyvale7)    | Role Design       | Back end    |
| Siyi Qian   | [Kikaze-K](https://github.com/Kikaze-K)        | Card & Map Design | Back end    |
| Wanying Ji  | [whynotsignin](https://github.com/whynotsignin)| Card & Map Design | Front end   |

# Contributions

Here lists contributors and their work till 8/3:

<a href="https://github.com/mraf2019/Wanderers/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=mraf2019/Wanderers" />
</a>

Made with [contrib.rocks](https://contrib.rocks).

## Overview

https://github.com/mraf2019/Wanderers/graphs/contributors

## Lan Wang (yexiaosu)

During the Unity game development, I played a key role in both the skeletal product and MVP stages. In the skeletal phase, I focused on crucial features like the player model, walking animation, and the collection and display of cards. Additionally, I worked on designing the start page, and UI elements, implementing the in-game settings menu, and the help page to enhance user experience.

In the MVP stage, I faced various challenges, including choosing Photon Pun as the server for smooth multiplayer interactions. I handled both front-end and back-end development to enable username setup and room hosting/joining. I also designed the logic for region shutdown and rewrote back-end functions to facilitate multiplayer card usage. Furthermore, I successfully created an RPC function to synchronize player health and hits across devices, ensuring a cohesive gaming experience. I also implemented the back-end of a shop/merchant system for virtual commerce during gameplay. 

## Siyi Qian (Kikaze-K)

Skeletal stage: enemy model and walking animation, minimap, camera motion update (y-axis depth of field), result page, collect loot, step-by-step tutorial guidance

MVP stage: The waiting room page with a player list and a host-only start button, realized the function that resources on the map will refresh after some time, added walk and hit animations for two new characters, rewrote the skill performance for the multiplayer game and updated the skill with cold down time, and realized the result page for players being killed or alive to the end. Besides, I also worked together with my teammates to fix bugs like the camera following a wrong character, players being spawned to a forbidden place (like inside a house model), and minimap display.

## Qi Lei (LeiQi7)

Skeletal stage: Overall map, collision of subjects and characters, skill attack, game status controller, pages linking

MVP stage: Database for all the cards, prefab of different characters and choosing character logics, the determination logic of player status and its indicator, some minor features and bugs. 

## Yiwei Zhang (Sunnyvale7)

Skeletal stage: Health bar UI design (both main character and enemies), character choosing page design, HP function, pages linking, bug fixes.

MVP stage: Realized loading the correct character prefabs and portraits given the choice of user in the character selection stage, Realized various prefabs generating, Designed the shop and currency UIs, Completing the currency and shop system, Designed a UI of game flow of creating and joining games, Completing the speed up/down and invincible status system, Realized username display and some other minor features. Helps fix bugs in aspects of card display, camera following, currency calculation and player spawning.

## Zefang Wei (mraf2019)

Skeletal stage: Overall UI design of the game page, including the layout and the parameters of all visual elements. Health bar UI design (main character)

MVP stage: Attributes and description of the cards. Art design of the cards. Solve server problems of Photon Unity Networking. Test and fix bugs.

## Wanying Ji (whynotsignin)

card design
