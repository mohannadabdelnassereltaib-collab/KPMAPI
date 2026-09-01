import LessonCard from "../Components/LessonCard";
import styles from "./LessonsLearned.module.css";

const lessons = [
  {
    name: "Hossam Shaban",
    title: "High-speed packaging line",
    badge: "Automation",
    theme: "automation",
    reviews: "13",
    description: "Optimizing PLC Logic for High-Speed Packaging",
  },
  {
    name: "Youssef Hany",
    title: "Wiring standardization",
    badge: "Electrical",
    theme: "electrical",
    reviews: "13",
    description: "Standardizing Wiring Diagrams for Global Clients",
  },
  {
    name: "Sarah Ahmed",
    title: "Operator console UX",
    badge: "Design",
    theme: "design",
    reviews: "13",
    description: "Improving Operator UX in Challenging Environments",
  },
];

function LessonsLearned() {
  return (
    <div className={styles.page}>
      <p className={styles.breadcrumb}>Home &gt; Lessons Learned</p>

      <div className={styles.head}>
        <div>
          <h1 className={styles.title}>Lessons Learned</h1>
          <p className={styles.intro}>
            A dedicated space for automation engineers to share lessons,
            challenges, and solutions discovered during project lifecycles.
          </p>
        </div>
        <button className={styles.createButton}>+ Create Lessons</button>
      </div>

      <div className={styles.filters}>
        <input className={styles.search} placeholder="Search for a lesson..." />
        <select className={styles.select}>
          <option>Department</option>
          <option>Automation</option>
          <option>Software Engineering</option>
          <option>Quality Assurance</option>
        </select>
        <select className={styles.select}>
          <option>Keywords</option>
          <option>PLC</option>
          <option>Packaging</option>
          <option>Wiring</option>
        </select>
        <button className={styles.applyButton}>Apply</button>
      </div>

      <select className={styles.groupSelect}>
        <option>Group by Department</option>
        <option>None</option>
      </select>

      <div className={styles.grid}>
        {lessons.map((lesson) => (
          <LessonCard
            key={lesson.name}
            name={lesson.name}
            title={lesson.title}
            badge={lesson.badge}
            theme={lesson.theme}
            reviews={lesson.reviews}
            description={lesson.description}
          />
        ))}
      </div>
    </div>
  );
}

export default LessonsLearned;
