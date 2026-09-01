import styles from "./LessonDetails.module.css";

function LessonDetails() {
  return (
    <div className={styles.page}>
      <p className={styles.breadcrumb}>Home &gt; Lesson Details</p>

      <div className={styles.layout}>
        <div className={styles.main}>
          <h1 className={styles.title}>
            Improving Operator UX in Challenging Environments
          </h1>
          <p className={styles.project}>Project: Automation Solutions Phase 2</p>

          <div className={styles.meta}>
            <div className={styles.author}>
              <span className={styles.avatar}>HS</span>
              <div>
                <p className={styles.authorName}>Hossam Shaaban</p>
                <p className={styles.authorRole}>Author</p>
              </div>
            </div>
            <p className={styles.rating}>
              <span className={styles.stars}>★★★★★</span> 4.6 (13 reviews)
            </p>
            <button className={styles.share}>Share</button>
          </div>

          <h2 className={styles.sectionTitle}>Lesson Summary</h2>
          <h3 className={styles.subTitle}>Description</h3>
          <p className={styles.text}>
            This lesson documents the specific logic adjustments made to the
            high-speed sorting system. It covers the challenges, root causes,
            and solutions discovered during the project lifecycle, including
            sensor feedback. By adjusting the task cycle time from 15ms to a
            variable execution model based on sensor triggers, the overall
            throughput was increased without compromising system stability.
          </p>

          <button className={styles.backButton}>&lt; Back to Lessons</button>
        </div>

        <aside className={styles.sidebar}>
          <div className={styles.panel}>
            <h4 className={styles.panelTitle}>Attachments</h4>
            <div className={styles.file}>
              <span className={styles.fileIcon}>📄</span>
              <div>
                <p className={styles.fileName}>PLC Logic_Rev4.pdf</p>
                <p className={styles.fileSize}>2.4 MB · PDF</p>
              </div>
            </div>
          </div>

          <div className={styles.panel}>
            <h4 className={styles.panelTitle}>Quick Links</h4>
            <p className={styles.link}>🔗 Internal Wiki - Automation</p>
          </div>

          <div className={styles.panel}>
            <h4 className={styles.panelTitle}>Keywords</h4>
            <div className={styles.chips}>
              <span className={styles.chip}>#automation</span>
              <span className={styles.chip}>#PLC</span>
              <span className={styles.chip}>#Packaging</span>
            </div>
          </div>

          <div className={styles.cta}>
            <h3 className={styles.ctaTitle}>Have a similar lesson?</h3>
            <p className={styles.ctaText}>
              Sharing your experience helps our engineering community grow
              stronger.
            </p>
            <button className={styles.ctaButton}>+ Create Lesson</button>
          </div>
        </aside>
      </div>
    </div>
  );
}

export default LessonDetails;
