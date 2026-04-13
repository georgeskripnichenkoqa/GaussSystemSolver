# 🧮 GaussSystemSolver

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET 9](https://img.shields.io/badge/.NET%209-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=for-the-badge&logo=blazor&logoColor=white)

A modern web-based calculator for solving systems of linear equations using the **Gaussian Elimination** method. This project bridges rigorous mathematical backend logic with an experimental "Nuclear UI."

## Visual Preview

<p align="center">
  <img src="docs/preview.jpg" alt="GaussSystemSolver main screen" width="900" />
</p>

<p align="center"><i>Main application screen</i></p>

## 🚀 About the Project

This application automates the process of solving Systems of Linear Algebraic Equations (SLAE). Simply input your coefficients, and the algorithm handles the heavy lifting of row reduction and variable calculation.

### Key Features:
* **Dynamic Grid:** Add or remove equations on the fly with a responsive interface.
* **Smart Validation:** The "Solve" button unlocks only when the system is mathematically ready for calculation.
* **Industrial Design:** A dark-themed "Nuclear UI" designed for focus and clarity.
* **Custom Tooltips:** Interactive, high-contrast tooltips for blocked actions.

### 📐 Mathematical Note
The solver utilizes a standard **Gaussian Elimination** algorithm. It is designed to find **one of the possible solutions** for a given system. Please note that for systems with infinite solutions (dependent systems), the algorithm will return a specific solution based on the row-reduction outcome.


<p align="center">
  <img src="docs/demo.gif" alt="GaussSystemSolver demo" width="900" />
</p>

<p align="center"><i>Quick demo</i></p>




## 🛠 Tech Stack

* **Core Logic:** C# / .NET 8
* **Web Framework:** Blazor WebAssembly (WASM)
* **Styling:** Pure CSS3 (featuring Flexbox and CSS Isolation)

## 🧪 Testing Strategy (The "Modular" Approach)
You won't find a `tests/` folder in this repository, and here is why:
* **Atomic Validation:** The project was developed in isolated logic blocks.
* **Dev-Time Coverage:** Each mathematical module was rigorously tested with temporary test-suites during its specific development phase.
* **Immutability:** Once a block (like the core Gauss algorithm) reached a "verified" state, it was frozen.
* **Manual Integration:** Final stability was confirmed through end-to-end manual testing within the UI (I'm a senior QA after all...).

*Basically: If it's not broken, I've already tested it while I was building it.*

---

## ⚠️ Disclaimer

> **Educational Purposes:** This project was created specifically for educational reasons to practice linear algebra algorithms and explore the Blazor ecosystem.

### Frontend Note (Backend-Dev Style) 🛠️
I am primarily a **Backend Developer** whose heart belongs to C# and strict typing. While exploring the frontend source code, you might notice:
* **Chaotic CSS:** Styles were written in a moment of inspiration and a desperate battle with `z-index`.
* **Experimental UI:** The layout might behave unpredictably if you click everything at once.
* **"It works - don't touch it" Principle:** The frontend is a mix of magic and "hacks" that somehow form a working interface.

If you are a frontend perfectionist, I recommend brewing some chamomile tea before inspecting the `.razor` and `.css` files.

---

## 🖥 Platform Support
While the core logic is built on cross-platform .NET, this specific build is configured as a **Standalone Windows Application**.
* **OS:** Windows 10 (1809+) or Windows 11.
* **Engine:** Uses WebView2 Runtime (included in modern Windows updates).


## 🏗 How to Run

1. Ensure you have the **.NET 9 SDK** installed.
2. Clone the repository:
   ```bash
   git clone [https://github.com/peoplessmusic/GaussSystemSolver.git](https://github.com/peoplessmusic/GaussSystemSolver.git)
