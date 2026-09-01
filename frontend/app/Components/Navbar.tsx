"use client";

import Link from "next/link";
import { usePathname } from "next/navigation";
import styles from "./Navbar.module.css";
import ThemeToggle from "./ThemeToggle";

const links = [
  { href: "/", label: "Home" },
  { href: "/LessonsLearned", label: "Lessons Learned" },
  { href: "#", label: "Processes" },
  { href: "#", label: "Projects and Libraries" },
];

function Navbar() {
  const pathname = usePathname();

  return (
    <header className={styles.header}>
      <nav className={styles.nav}>
        <Link href="/" className={styles.logo}>
          <span className={styles.logoMark}>A</span>
          Advansys
        </Link>
        <div className={styles.links}>
          {links.map((link) => (
            <Link
              key={link.label}
              href={link.href}
              className={
                pathname === link.href
                  ? `${styles.link} ${styles.active}`
                  : styles.link
              }
            >
              {link.label}
            </Link>
          ))}
        </div>
        <div className={styles.actions}>
          <Link href="/Chatbot" className={styles.chatLink}>
            💬
          </Link>
          <ThemeToggle />
        </div>
      </nav>
    </header>
  );
}

export default Navbar;
