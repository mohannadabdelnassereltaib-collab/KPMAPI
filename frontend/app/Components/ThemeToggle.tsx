"use client";

import { useState } from "react";
import styles from "./ThemeToggle.module.css";

function ThemeToggle() {
  const [dark, setDark] = useState(true);

  function toggleTheme() {
    setDark(!dark);
    document.documentElement.classList.toggle("light");
  }

  return (
    <button className={styles.toggle} onClick={toggleTheme}>
      {dark ? "☀️" : "🌙"}
    </button>
  );
}

export default ThemeToggle;
