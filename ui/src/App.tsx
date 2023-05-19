import { Layout } from 'antd';
import LeadManagementPage from './pages/LeadManagementPage';
import React from 'react';
import { QueryClient, QueryClientProvider } from 'react-query';

const queryClient = new QueryClient();

class App extends React.Component {

  render() {
    return (
      <div className="App">
        <QueryClientProvider client={queryClient}>
          <Layout>
            <Layout.Content style={{ padding: '50px' }}>
              <LeadManagementPage />
            </Layout.Content>
          </Layout>
        </QueryClientProvider>

      </div>
    );
  }
}

export default App;
