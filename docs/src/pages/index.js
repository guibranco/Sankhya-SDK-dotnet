import React from 'react';
import Layout from '@theme/Layout';

/**
 * Home component that renders the main layout for the Sankhya SDK documentation.
 *
 * This component serves as the entry point for the documentation page, providing
 * a title and description for the layout, along with a welcome message and an
 * introductory paragraph for users.
 *
 * @returns {JSX.Element} The rendered layout component containing the documentation
 *                        welcome message and description.
 *
 * @example
 * // Usage of the Home component
 * const App = () => (
 *   <div>
 *     <Home />
 *   </div>
 * );
 */
function Home() {
  return (
    <Layout
      title="Sankhya SDK Documentation"
      description="Comprehensive documentation for Sankhya SDK">
      <main>
        <h1>Welcome to Sankhya SDK Documentation</h1>
        <p>Explore the documentation to understand how to use the Sankhya SDK effectively.</p>
      </main>
    </Layout>
  );
}

export default Home;