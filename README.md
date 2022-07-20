# GOAP

An iterative process to creating an implementation of "**Goal Oriented Action Planning**" (**GOAP**)
[Here](https://alumni.media.mit.edu/~jorkin/goap.html) is a link that points to a lot of good reading material about the topic. 

**TLDR**: Game AI  that is aware about it's and the world's state and actually PLANS what it is going to do when the state changes. This leads to intelligent behaviour such as (in combat games) taking actions such as taking tactical cover, throwing grenades when it detects player is hiding behind cover to flush player out of cover, trying to preserve its own life if it has run out of ammo, etc.

<br></br>
Objective: Create a **scalable**, **modular** and **performant** small-scale implementation of **GOAP** in C# and Unity.

Iterations I am taking:

 - [x] Create **Pushdown Automata State Machine** for AI agents.
 - [x] Create framework of an individual **Action** that all "actions" of that an agent performs derive from.
 - [x] Make the agent **Stateful**, in preparation of adding "preconditions" and "effects" of Actions.
 - [x] Make temporary hard coded "**Action Plans**" for testing if agents switch States and Actions as and when needed.
 - [ ]  Actually implement **Preconditions** and **Effects** affecting they agents State as they traverse the hard coded Action plans.
 - [ ] Create **Action Planner** that creates *graphs* pertaining to all the possible paths an agent can take towards its (simple) goal, given its current state.
 - [ ] Implement  [A-Star algorithm](https://github.com/harshdulani/A-Pathfinding-For-Unity) to be used to find shortest path (shortest Action Plan) from current state for the planner.
 - [ ] Implement a **Regressive A star** that backtracks and finds shortest path from goal state to current state, which should be a faster approach as the number of available Actions increase. *(optional)*
 - [ ] Add changing of world and agent state conditions, hence the agents changing the action plans on the fly.
 - [ ] ...
 - [ ] Create a node based editor so Game Designers/Non-Programmers can also author actions (?)
 - [ ] ...
 - [ ]  Port to C++ for Unreal (?)
 - [ ] ...
 - [ ] ...
 - [ ] Develop F.E.A.R. for Monolith Studios and give GDC talk (?)
