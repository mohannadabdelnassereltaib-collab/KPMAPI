import Link from "next/link";
import styles from "./page.module.css";

function Home() {
  return (
    <div className={styles.hero}>
      <h1 className={styles.title}>Welcome to KPM</h1>
      <p className={styles.text}>
        A dedicated space for automation engineers to share lessons,
        challenges, and solutions discovered during project lifecycles.
      </p>
      <div className={styles.actions}>
        <Link href="/LessonsLearned" className={styles.primary}>
          Browse Lessons
        </Link>
        <Link href="/Chatbot" className={styles.outline}>
          Open AI Assistant
        </Link>
      </div>
    </div>
  );
}

export default Home;
