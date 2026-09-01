import styles from "./Footer.module.css";

function Footer() {
  return (
    <footer className={styles.footer}>
      <div className={styles.inner}>
        <span>
          <strong>Advansys</strong> © 2026 Advansys Intelligent Solutions. All
          rights reserved.
        </span>
        <div className={styles.links}>
          <a href="#">Privacy Policy</a>
          <a href="#">Terms of Service</a>
          <a href="#">Support</a>
        </div>
      </div>
    </footer>
  );
}

export default Footer;
