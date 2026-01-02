# Vulcan Learning Pit

A WPF (.NET 10) educational training application inspired by the Vulcan learning environment from Star Trek (2009). Students solve fast, focused problems in math, logic, reading, and science under time pressure, guided by an elder Spock-style mentor avatar.

## 🖖 Overview

Vulcan Learning Pit is designed to help students in grades 4-8 master core academic concepts through adaptive learning, time-based challenges, and motivational rewards. The system intelligently targets weaknesses, supports students with ADD through topic switching, and uses earned progression, tokens, and leaderboards to motivate mastery without artificial hype.

## ✨ Features

### Core Functionality
- **Adaptive Difficulty System**: Automatically adjusts problem difficulty based on student performance
- **Four Subject Areas**: 
  - 🔢 Mathematics (addition, subtraction, multiplication, division)
  - 🧩 Logic (patterns, sequences, puzzles)
  - 📖 Reading Comprehension
  - 🔬 Science (biology, physics, earth science)
- **Grade-Level Targeting**: Supports grades 4-8 with age-appropriate content
- **Time Pressure Mechanics**: Each problem has a countdown timer to encourage focus
- **Spock-Style Mentor**: Encouraging and wise guidance throughout the learning journey

### ADD/ADHD Support
- **Quick Topic Switching**: Students can switch between subjects at any time
- **Short, Focused Sessions**: Problems are designed for quick completion
- **Variety**: Multiple problem types within each subject to maintain engagement

### Motivation & Progression
- **Token System**: Earn tokens for correct answers, with bonuses for speed
- **Point Scoring**: Track progress with a comprehensive scoring system
- **Leaderboard**: Compete with other students (sample data included)
- **Achievements**: Special recognition for milestones
- **Elder Spock Encouragement**: Contextual messages that provide motivation and wisdom

### Intelligent Adaptation
- **Weakness Detection**: System identifies subjects where the student struggles
- **Difficulty Progression**: 4 difficulty levels (Easy, Medium, Hard, Expert)
- **Performance Tracking**: Detailed statistics for each subject including:
  - Success rate
  - Average response time
  - Consecutive correct/incorrect streaks
  - Current difficulty level

## 🚀 Getting Started

### Prerequisites
- .NET 10 SDK
- Windows operating system (for WPF)

### Building the Application

```bash
cd VulcanLearningPit
dotnet restore
dotnet build
```

### Running the Application

```bash
cd VulcanLearningPit
dotnet run
```

Or open the solution in Visual Studio and press F5.

## 🎮 How to Use

1. **Start Training**:
   - Enter your name
   - Select your grade level (4-8)
   - Click "START TRAINING SESSION"

2. **Solve Problems**:
   - Read the question carefully
   - Select your answer from the multiple choice options
   - Click "SUBMIT ANSWER" before time runs out
   - Review the feedback from the mentor

3. **Progress**:
   - Click "NEXT PROBLEM" to continue
   - Use "Switch Subject" to change topics (helpful for ADD/ADHD)
   - Watch your tokens and score accumulate

4. **End Session**:
   - Click "END SESSION" when you're done
   - View your total score and tokens earned

5. **View Leaderboard**:
   - Click the "🏆 Leaderboard" button in the header
   - See how you rank against other students

## 🏗️ Architecture

### Project Structure
```
VulcanLearningPit/
├── Models/              # Data models
│   ├── GradeLevel.cs
│   ├── SubjectType.cs
│   ├── DifficultyLevel.cs
│   ├── StudentProfile.cs
│   ├── Problem.cs
│   ├── ProblemSession.cs
│   └── Leaderboard.cs
├── Services/            # Business logic
│   ├── ProblemGeneratorService.cs
│   ├── AdaptiveDifficultyService.cs
│   └── SessionService.cs
├── ViewModels/          # MVVM ViewModels
│   ├── ViewModelBase.cs
│   ├── RelayCommand.cs
│   ├── MainViewModel.cs
│   └── LeaderboardViewModel.cs
├── Views/               # Additional windows
│   └── LeaderboardWindow.xaml
├── Converters.cs        # Value converters
└── MainWindow.xaml      # Main application window
```

### Key Components

#### ProblemGeneratorService
Generates problems dynamically for all four subject areas with appropriate difficulty scaling.

#### AdaptiveDifficultyService
Analyzes student performance and adjusts difficulty levels intelligently:
- Increases difficulty after 3 consecutive correct answers
- Decreases difficulty after 3 consecutive incorrect answers
- Considers overall success rate for longer-term adjustments

#### SessionService
Manages the learning session lifecycle:
- Tracks current problems and student answers
- Calculates scores and tokens
- Updates student statistics
- Handles subject switching

## 🎨 UI Design

The application features a Star Trek-inspired dark theme with cyan (#00d4ff) accents:
- **Color Scheme**: Dark blue backgrounds (#1a1a2e, #16213e) with bright cyan highlights
- **Mentor Avatar**: 🖖 Vulcan salute emoji representing Spock
- **Visual Feedback**: Clear color coding for different elements (gold for tokens, green for score)
- **Professional Typography**: Clean, readable fonts with appropriate sizing

## 🧠 Educational Philosophy

Inspired by the Vulcan approach to learning:
- **Logic and Reason**: Problems emphasize critical thinking
- **Mastery Through Practice**: Repeated exposure with increasing difficulty
- **Emotional Control**: The mentor provides calm, encouraging guidance
- **Continuous Improvement**: The system adapts to help students overcome weaknesses

## 📈 Adaptive Learning Algorithm

The system uses multiple metrics to determine the next appropriate challenge:

1. **Consecutive Performance**: Quick adjustments based on recent answers
2. **Success Rate**: Long-term performance across multiple problems
3. **Subject Weakness Detection**: Identifies areas needing more practice
4. **Random Variety**: 30% chance of random subject selection to maintain engagement

## 🏆 Scoring System

- **Base Points**: 10-50 points per problem based on difficulty
- **Time Bonuses**:
  - ≤50% of time used: +15 points, +1 token
  - ≤75% of time used: +10 points, +1 token
  - ≤100% of time used: +5 points, +1 token
- **Tokens**: 1-5 tokens per correct answer based on difficulty

## 🔮 Future Enhancements

Potential additions for future versions:
- Persistent data storage (database or file-based)
- More problem types and subjects
- Detailed progress reports and analytics
- Multiplayer challenges
- Achievement system with unlockables
- Parent/teacher dashboard
- Audio feedback and sound effects
- Customizable mentor avatars

## 📝 License

See LICENSE file for details.

## 🖖 Live Long and Prosper

May your journey through the Vulcan Learning Pit bring you knowledge, wisdom, and mastery.

---

*"Logic is the beginning of wisdom, not the end."* - Spock
