# Contributing to Middle-earth Adventure RPG

Thank you for your interest in contributing to Middle-earth Adventure RPG! This guide will help you get started with contributing to the project, including how to report issues, share screenshots, and submit changes.

---

## Table of Contents

1. [Ways to Contribute](#ways-to-contribute)
2. [Reporting Issues](#reporting-issues)
3. [Sharing Screenshots from Godot](#sharing-screenshots-from-godot)
4. [Contributing Code](#contributing-code)
5. [Documentation](#documentation)
6. [Getting Help](#getting-help)

---

## Ways to Contribute

There are many ways to contribute to this project:

- 🐛 **Report bugs** - Help us identify and fix issues
- 💡 **Suggest features** - Share your ideas for improvements
- 📸 **Share screenshots** - Show us what you're working on or issues you've found
- 💻 **Submit code** - Fix bugs or add new features
- 📝 **Improve documentation** - Help make our guides clearer
- 🎨 **Create assets** - Contribute 3D models, textures, or sounds
- 🧪 **Test changes** - Try out new features and provide feedback

---

## Reporting Issues

When you find a bug or want to suggest an enhancement:

1. **Check existing issues** - Search [GitHub Issues](https://github.com/S3OPS/MiddleEarthRPG/issues) to see if it's already reported
2. **Create a new issue** - Click "New Issue" and choose the appropriate template
3. **Provide details:**
   - **Title**: Brief description (e.g., "Player falls through ground in The Shire")
   - **Description**: What happened, what you expected, steps to reproduce
   - **Environment**: OS, Godot version, game version
   - **Screenshots**: Visual evidence helps immensely (see below!)

---

## Sharing Screenshots from Godot

Screenshots are incredibly valuable for showing bugs, demonstrating features, or sharing your work. Here's how to capture and share them:

### Method 1: Taking Screenshots While Playing (Easiest)

When the game is running:

1. **Play the game** - Press **F5** in Godot to start the game
2. **Navigate to the area** you want to capture
3. **Take a screenshot using your OS:**
   - **Windows**: Press `Win + Shift + S` (Snipping Tool) or `PrtScn` (full screen)
   - **macOS**: Press `Cmd + Shift + 4` (select area) or `Cmd + Shift + 3` (full screen)
   - **Linux**: Press `PrtScn` or use your distribution's screenshot tool

4. **Save the screenshot** to a memorable location (Desktop or Screenshots folder)

### Method 2: Taking Screenshots in the Godot Editor

To capture the editor view (useful for showing scene setup or errors):

1. **In Godot Editor**, arrange the view you want to capture
2. **Use your OS screenshot tool** (same shortcuts as above)
3. Alternatively, you can use Godot's built-in capture:
   - **Debug → Take Screenshot** (if available in your Godot version)

### Method 3: Using Godot's Built-in Screenshot Function

For developers adding screenshot functionality to the game:

```gdscript
# Take a screenshot and save it
func take_screenshot():
    var img = get_viewport().get_texture().get_image()
    var timestamp = Time.get_datetime_string_from_system()
    var filename = "screenshot_" + timestamp + ".png"
    img.save_png("user://screenshots/" + filename)
    print("Screenshot saved: ", filename)
```

### How to Share Your Screenshots

#### Option 1: GitHub Issues (Recommended)

1. **Go to** [GitHub Issues](https://github.com/S3OPS/MiddleEarthRPG/issues)
2. **Click** "New Issue"
3. **Fill in the details** and then:
4. **Drag and drop** your screenshot(s) directly into the description box, OR
5. **Click the image icon** 📷 in the toolbar and select your screenshot(s)
6. **Submit the issue**

GitHub will automatically upload and embed your images!

#### Option 2: Pull Requests

When submitting a pull request with visual changes:

1. **Create your PR** as normal
2. **In the PR description**, add a "Screenshots" section:
   ```markdown
   ## Screenshots
   
   ### Before
   ![Before changes](screenshot1.png)
   
   ### After
   ![After changes](screenshot2.png)
   ```
3. **Drag and drop** screenshots into the description

#### Option 3: Cloud Storage Links

For multiple screenshots or video recordings:

1. **Upload to cloud storage:**
   - Google Drive (public link)
   - Imgur (free image hosting)
   - GitHub Gist (for organized collections)
   
2. **Share the link** in your issue or PR

### Screenshot Best Practices

✅ **DO:**
- Include the relevant area clearly in frame
- Take screenshots at a readable resolution (at least 720p)
- Show the context (UI, environment, player position)
- Capture error messages or console output if present
- Take multiple angles if it helps explain the issue

❌ **DON'T:**
- Upload extremely large files (compress if over 5MB)
- Share screenshots with personal information visible
- Use blurry or unclear captures

### Taking Multiple Screenshots for a Sequence

If you need to show a bug that happens over time:

1. **Take screenshot 1** - Initial state
2. **Take screenshot 2** - During the action
3. **Take screenshot 3** - Final result/bug
4. **Share all three** with numbered captions explaining each step

Example:
```markdown
## Bug Reproduction

1. **Starting position**: Player near the bridge
   ![Step 1](screenshot1.png)

2. **Walking across bridge**: Movement looks normal
   ![Step 2](screenshot2.png)

3. **Player falls through**: Character falls through bridge
   ![Step 3](screenshot3.png)
```

---

## Contributing Code

### Setting Up Development Environment

1. **Install Godot 4.3+** - See [GETTING_STARTED.md](docs/GETTING_STARTED.md)
2. **Fork the repository** on GitHub
3. **Clone your fork:**
   ```bash
   git clone https://github.com/YOUR_USERNAME/MiddleEarthRPG.git
   cd MiddleEarthRPG
   ```
4. **Open in Godot** and test that everything works

### Making Changes

1. **Create a new branch:**
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. **Make your changes** in Godot or your preferred editor

3. **Test your changes:**
   - Press **F5** to run the game
   - Test all affected features
   - Check for errors in Output panel

4. **Commit your changes:**
   ```bash
   git add .
   git commit -m "Add feature: brief description"
   ```

5. **Push to your fork:**
   ```bash
   git push origin feature/your-feature-name
   ```

6. **Create a Pull Request** on GitHub:
   - Go to the original repository
   - Click "Pull Requests" → "New Pull Request"
   - Select your branch
   - Fill in the PR template with:
     - What you changed
     - Why you changed it
     - Screenshots (if applicable)
     - Testing performed

### Code Style Guidelines

- **Use GDScript** for all game logic (Godot's native language)
- **Follow Godot naming conventions:**
  - Variables: `snake_case`
  - Functions: `snake_case()`
  - Classes: `PascalCase`
  - Constants: `SCREAMING_SNAKE_CASE`
- **Comment complex logic** - Help others understand your code
- **Use signals** for communication between nodes
- **Keep scripts modular** - One responsibility per script

### Testing Your Changes

Before submitting:

- ✅ Game runs without errors (check Output panel)
- ✅ Your feature works as intended
- ✅ Existing features still work (regression testing)
- ✅ No new warnings in the console
- ✅ Performance is acceptable (check FPS)

---

## Documentation

Documentation improvements are always welcome!

### Updating Existing Documentation

1. **Find the file** in the `docs/` directory
2. **Edit using Markdown** syntax
3. **Follow the existing structure** and tone
4. **Submit a PR** with your changes

### Creating New Documentation

If you're adding a new feature that needs documentation:

1. **Create a new `.md` file** in the `docs/` directory
2. **Follow the structure** of existing documentation:
   - Clear headings
   - Table of contents for long documents
   - Code examples where relevant
   - Screenshots for visual features
3. **Link to it** from relevant documents (README.md, GETTING_STARTED.md, etc.)

---

## Getting Help

Need assistance or have questions?

### Discord/Community (if available)
- Join our community server for real-time help

### GitHub Discussions
- Use [GitHub Discussions](https://github.com/S3OPS/MiddleEarthRPG/discussions) for:
  - Questions about development
  - Feature discussions
  - General help

### GitHub Issues
- Use for reporting bugs and requesting features
- Include as much detail as possible
- Screenshots are very helpful!

### Documentation
- Check existing docs in the `docs/` folder:
  - [GETTING_STARTED.md](docs/GETTING_STARTED.md) - Installation and setup
  - [GAME_DESIGN.md](docs/GAME_DESIGN.md) - Technical specifications
  - [REPOSITORY_STRUCTURE.md](docs/REPOSITORY_STRUCTURE.md) - Code organization

---

## Code of Conduct

Be respectful and constructive:

- 🤝 Be welcoming to newcomers
- 💬 Provide constructive feedback
- 🎯 Stay on topic
- 🚫 No harassment or discrimination
- ✨ Help make the community positive and inclusive

---

## Recognition

Contributors are recognized in:
- Git commit history
- Release notes (for significant contributions)
- CHANGELOG.md

---

## Questions?

If you have questions about contributing that aren't answered here:

1. Check the [README.md](README.md) for project overview
2. Review the [GETTING_STARTED.md](docs/GETTING_STARTED.md) guide
3. Open a [Discussion](https://github.com/S3OPS/MiddleEarthRPG/discussions) on GitHub
4. Or create an issue with the "question" label

---

**Thank you for contributing to Middle-earth Adventure RPG!** 🎮✨

Every contribution, no matter how small, helps make this game better for everyone.

---

**Last Updated:** January 2026  
**Document Version:** 1.0
