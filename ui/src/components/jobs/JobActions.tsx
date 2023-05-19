import React from 'react';
import { Row, Col, Button } from 'antd';
import styled from 'styled-components';

interface JobActionProps {
  price: number;
  onAccept: () => void;
  onDecline: () => void;
}

const StyledCustomPrimaryButton = styled(Button)`
  background-color: rgb(247,135,16) !important;
  border-color: rgb(247,135,16) !important;
  width: 125px;
  border-radius: 0 !important;
  font-weight: bolder !important;
`;

const StyledCustomSecondaryButton = styled(Button)`
  background-color: rgb(216,209,202) !important;
  color: rgb(72, 72, 72) !important;
  border-color: rgb(216,209,202) !important;
  width: 125px;
  border-radius: 0 !important;
  font-weight: bolder !important;
`;

const Price = styled.span`
  font-weight: bold;
`;

export const JobActions: React.FC<JobActionProps> = ({ price, onAccept, onDecline }) => {
  return (
    <Row gutter={8}>
      <Col>
        <StyledCustomPrimaryButton size="middle" onClick={onAccept}>
          Accept
        </StyledCustomPrimaryButton>
      </Col>
      <Col>
        <StyledCustomSecondaryButton size="middle" onClick={onDecline}>
          Decline
        </StyledCustomSecondaryButton>
      </Col>
      <Col className="p-2">
        <Price>${price.toFixed(2)}</Price> Lead Invitation
      </Col>
    </Row>
  );
};