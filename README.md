# Spock Learning

Rapid-learning assistant for grades 4-college with a Spock mentor motif. See docs/plan.md for the plan-only specification (includes parent dashboard scope and rapid-acceleration rules). Implementation stack is intentionally undecided so we can adapt to your preferences and constraints.

## Structure

- docs/plan.md: Current motivation and curriculum spec (expanded to parent dashboard and rapid acceleration).
- src/: Placeholder for engine and UI code (not yet scaffolded).
- .vscode/mcp.json: Local MCP config wiring Context7 via npx (no API key included).

## Next steps

- Decide on the initial tech stack (web, mobile, or CLI prototype).
- Outline the adaptive engine data model and state machine.
- Pick a persistence approach for tracking weaknesses and sessions.
- Define minimal UI wireframes for learner view and parent dashboard.
- Add a CONTEXT7_API_KEY env var (if you have one) before running the MCP locally for higher limits.
