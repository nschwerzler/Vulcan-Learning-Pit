# Vulcan-Learning-Pit

A learning repository with multiple project management methodologies to choose from.

## 📋 Project Management Options

This repository supports three different project management approaches. Choose the one that best fits your team's workflow:

### 1. Kanban Board *(Available in separate PR)*
**Best for:** Continuous flow, visualizing work, limiting work-in-progress

Kanban is a visual workflow management method that emphasizes continuous delivery without overburdening the team.

- 📖 Kanban Guide - Complete methodology guide *(See PR #4)*
- 🔧 Setup Instructions - Step-by-step setup *(See PR #4)*
- 📝 Issue Templates: Task, Bug, Feature

**Key Features:**
- Visual workflow columns (Backlog → To Do → In Progress → Review → Done)
- Work-in-progress (WIP) limits
- Continuous flow without sprints
- Pull-based system

### 2. Scrum Board
**Best for:** Sprint-based development, defined ceremonies, cross-functional teams

Scrum is an agile framework using fixed-length sprints (iterations) with regular ceremonies and defined roles.

- 📖 [Scrum Guide](SCRUM.md) - Complete methodology guide
- 🔧 [Setup Instructions](.github/SCRUM_SETUP.md) - Step-by-step setup
- 📝 Issue Templates: User Story, Sprint Task, Bug, Technical Debt

**Key Features:**
- Sprint-based work cycles (typically 2 weeks)
- Story point estimation (Fibonacci scale)
- Daily standups, sprint planning, reviews, and retrospectives
- Product backlog with prioritization
- Velocity tracking and burndown charts

### 3. Project Tracker
**Best for:** Small teams, flexible planning, long-term projects, mixed work types

A simple, flexible approach for teams that need less formal structure than Scrum but want more organization than ad-hoc.

- 📖 [Project Tracker Guide](PROJECT-TRACKER.md) - Complete methodology guide
- 🔧 [Setup Instructions](.github/PROJECT_TRACKER_SETUP.md) - Step-by-step setup
- 📝 Issue Templates: Initiative, Milestone, Task, Research, Bug

**Key Features:**
- Flexible column structure (Ideas → Planned → Active → Testing/Review → Completed → On Hold)
- T-shirt sizing (XS/S/M/L/XL) for estimates
- Milestone-based planning
- On Hold column for blocked work
- Weekly planning cycles

## 🚀 Getting Started

1. **Choose your methodology** - Review the guides above to select the best fit
2. **Follow setup instructions** - Each methodology has detailed setup docs
3. **Create your board** - Use GitHub Projects to create your board
4. **Configure issue templates** - Templates are in `.github/ISSUE_TEMPLATE/`
5. **Start working** - Create issues and manage your workflow

## 📚 Quick Reference

### When to Use Each Method

| Situation | Recommended Approach |
|-----------|---------------------|
| Continuous delivery, mature process | **Kanban** |
| New team learning agile | **Scrum** |
| Fixed release cycles | **Scrum** |
| Small team (1-5 people) | **Project Tracker** |
| Research-heavy work | **Project Tracker** |
| External dependencies | **Project Tracker** |
| Large cross-functional team | **Scrum** |
| Support/maintenance work | **Kanban** |

### Comparison Matrix

| Feature | Kanban | Scrum | Project Tracker |
|---------|---------|--------|-----------------|
| **Iterations** | Continuous | Fixed sprints | Flexible |
| **Roles** | Flexible | Defined | Flexible |
| **Ceremonies** | Optional | Required | Minimal |
| **Estimation** | Optional | Story points | T-shirt sizes |
| **Planning** | Continuous | Sprint-based | Weekly/Monthly |
| **Change Friendly** | ✅ High | ⚠️ Limited | ✅ High |
| **Learning Curve** | 🟢 Easy | 🟡 Medium | 🟢 Easy |
| **Best For** | Ops/Support | Product Dev | Small Teams |

## 🔄 Switching Methodologies

You can switch between methodologies as your team evolves:

- **Kanban → Scrum**: Add sprints and ceremonies when ready for more structure
- **Scrum → Kanban**: Remove sprints for continuous flow
- **Project Tracker → Kanban**: Add WIP limits and refine process
- **Project Tracker → Scrum**: Add story points and sprint cadence

See each methodology's guide for migration tips.

## 📖 Documentation

- Kanban methodology guide *(Available in PR #4)*
- [SCRUM.md](SCRUM.md) - Scrum methodology guide
- [PROJECT-TRACKER.md](PROJECT-TRACKER.md) - Project Tracker guide
- [CHOOSING-A-METHODOLOGY.md](CHOOSING-A-METHODOLOGY.md) - Guide to selecting the right approach
- [Issue Templates](.github/ISSUE_TEMPLATE/) - All issue templates
- [Workflows](.github/workflows/) - GitHub Actions automations

## 🤝 Contributing

1. Choose the appropriate methodology board
2. Create an issue using the provided templates
3. Issues are automatically added to the project board
4. Follow your team's workflow process

## 📝 License

MIT License - See [LICENSE](LICENSE) for details

## 🆘 Need Help?

- Review the methodology guides for detailed information
- Check the setup instructions for board configuration
- Refer to issue templates for creating work items
- Consult GitHub Projects documentation for platform features