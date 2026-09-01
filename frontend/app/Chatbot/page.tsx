import styles from "./Chatbot.module.css";

function Chatbot() {
  return (
    <div className={styles.page}>
      <aside className={styles.sidebar}>
        <h1 className={styles.brand}>🤖 AI Assistant</h1>
        <p className={styles.historyLabel}>History</p>
        <p className={styles.historyText}>All your chats are saved here.</p>
        <button className={styles.newChat}>+ New Conversation</button>
      </aside>

      <div className={styles.chat}>
        <div className={styles.messages}>
          <div className={styles.bubble}>Hello, How can I help you today?</div>
          <p className={styles.hint}>
            You can ask about lessons, projects, or processes.
          </p>
        </div>
        <div className={styles.inputBar}>
          <input
            className={styles.input}
            placeholder="Ask me anything about your knowledge base..."
          />
          <button className={styles.send}>➤</button>
        </div>
      </div>
    </div>
  );
}

export default Chatbot;
