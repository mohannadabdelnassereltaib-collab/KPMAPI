import styles from "./LessonCard.module.css";

function LessonCard(props: {
  name: string;
  title: string;
  badge: string;
  theme: string;
  reviews: string;
  description: string;
}) {
  return (
    <div className={styles.card}>
      <div className={`${styles.image} ${styles[props.theme]}`}>
        <span className={styles.badge}>{props.badge}</span>
        <h2 className={styles.title}>{props.title}</h2>
      </div>

      <div className={styles.content}>
        <p className={styles.name}>{props.name}</p>
        <p className={styles.rating}>
          <span className={styles.stars}>★★★★★</span> ({props.reviews})
        </p>
        <p className={styles.description}>{props.description}</p>
        <button className={styles.button}>Open Lesson</button>
      </div>
    </div>
  );
}

export default LessonCard;
