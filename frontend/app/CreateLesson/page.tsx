import styles from "./CreateLesson.module.css";

function CreateLesson() {
  return (
    <div className={styles.page}>
      <p className={styles.breadcrumb}>Home &gt; Create Lesson</p>
      <h1 className={styles.title}>Create Lesson</h1>
      <p className={styles.subtitle}>
        Fill in the details below to create a new knowledge base lesson.
      </p>

      <div className={styles.layout}>
        <div className={styles.form}>
          <h2 className={styles.sectionTitle}>Basic Information</h2>

          <label className={styles.label} htmlFor="lessonTitle">
            Lesson Title *
          </label>
          <input
            id="lessonTitle"
            className={styles.input}
            placeholder="Enter lesson title"
          />

          <label className={styles.label} htmlFor="projectName">
            Project Name *
          </label>
          <input
            id="projectName"
            className={styles.input}
            placeholder="Enter project name"
          />

          <label className={styles.label} htmlFor="industry">
            Industry *
          </label>
          <select id="industry" className={styles.input}>
            <option>Select industry</option>
            <option>Automation</option>
            <option>Electrical</option>
            <option>Software</option>
          </select>

          <h2 className={styles.sectionTitle}>Lesson Content</h2>

          <label className={styles.label} htmlFor="description">
            Description *
          </label>
          <textarea
            id="description"
            className={styles.textarea}
            rows={5}
            placeholder="Write the full description of the lesson..."
          ></textarea>

          <label className={styles.label}>Attachments</label>
          <div className={styles.uploads}>
            <div className={styles.upload}>
              <p className={styles.uploadText}>Click to upload or drag and drop</p>
              <p className={styles.uploadHint}>SVG, PNG, JPG or GIF (max 5MB)</p>
            </div>
            <div className={styles.upload}>
              <p className={styles.uploadText}>Click to upload or drag and drop</p>
              <p className={styles.uploadHint}>PDF, DOCX, or PPTX (max 5MB)</p>
            </div>
          </div>
          <p className={styles.noFiles}>No files attached yet</p>

          <div className={styles.actions}>
            <button className={styles.outlineButton}>Discard</button>
            <button className={styles.outlineButton}>Save as Draft</button>
            <button className={styles.primaryButton}>Submit Lesson +</button>
          </div>
        </div>

        <aside className={styles.summary}>
          <h2 className={styles.summaryTitle}>Review Summary</h2>

          <h3 className={styles.groupTitle}>Basic Information</h3>
          <div className={styles.row}>
            <span>Lesson Title</span>
            <span className={styles.value}>Not provided</span>
          </div>
          <div className={styles.row}>
            <span>Project Name</span>
            <span className={styles.value}>Not provided</span>
          </div>
          <div className={styles.row}>
            <span>Industry</span>
            <span className={styles.value}>Not provided</span>
          </div>
          <div className={styles.row}>
            <span>Section</span>
            <span className={styles.value}>Not provided</span>
          </div>

          <h3 className={styles.groupTitle}>Lesson Content</h3>
          <div className={styles.row}>
            <span>Description</span>
            <span className={styles.value}>Not provided</span>
          </div>

          <h3 className={styles.groupTitle}>Attachments</h3>
          <div className={styles.row}>
            <span>Files</span>
            <span className={styles.value}>0 items</span>
          </div>

          <div className={styles.row}>
            <span>Status</span>
            <span className={styles.value}>Not provided</span>
          </div>
        </aside>
      </div>
    </div>
  );
}

export default CreateLesson;
