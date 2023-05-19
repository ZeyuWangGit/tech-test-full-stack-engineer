import React from "react";
import { Tabs, Spin, Row, Col, Space } from 'antd';
import { Job } from "../services/JobService";
import { InvitedDetailCard } from "../components/lead-cards/InvitedLeadDetailCard";
import { AcceptedLeadDetailCard } from "../components/lead-cards/AcceptedLeadDetailCard";
import styled from "styled-components";
import { useLeadManagementPage } from "./useLeadManagementPage";

const { TabPane } = Tabs;

const StyledTab = styled(Tabs)`
.ant-tabs-nav-list {
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 100%;
  background-color: white;
}

.ant-tabs-tab {
  width: 50%;
  justify-content: center;
}

.ant-tabs-tab.ant-tabs-tab-active .ant-tabs-tab-btn {
  color: #363636 !important; 
  font-weight: 500;
}

.ant-tabs-ink-bar {
  position: absolute;
  background: rgb(241,161,76);
  pointer-events: none;
}
`

const LeadManagementPage: React.FC = () => {

  const {
    acceptedJobs,
    invitedJobs,
    isLoading,
    onJobAccepted,
    onJobDeclined,
  } = useLeadManagementPage();

  return (
    <Spin spinning={isLoading}>
      <Row justify="center">
        <Col span={15}>
          <StyledTab defaultActiveKey="1" centered >
            <TabPane tab="Invited" key="1">
              <Space direction="vertical" size="middle" style={{ display: 'flex' }}>
                {invitedJobs?.map((job: Job) => (
                  <InvitedDetailCard
                    job={job}
                    key={job.id}
                    onJobAccepted={onJobAccepted}
                    onJobDeclined={onJobDeclined}
                  />
                ))}
              </Space>
            </TabPane>
            <TabPane tab="Accepted" key="2">
              <Space direction="vertical" size="middle" style={{ display: 'flex' }}>
                {acceptedJobs?.map((job: Job) => (
                  <AcceptedLeadDetailCard job={job} key={job.id} />
                ))}
              </Space>
            </TabPane>
          </StyledTab>
        </Col>
      </Row>
    </Spin>
  );
}

export default LeadManagementPage;
