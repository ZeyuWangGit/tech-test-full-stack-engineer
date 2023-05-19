import React from "react";
import { Row, Col, Typography } from 'antd';
import styled from 'styled-components';
import getJobCreatedDateTimeString from "../../common/utils/datetime";

interface UserInfoProps {
    name: string;
    jobCreatedDateTime: string;
}

const StyledCircle = styled.div`
  display: flex;
  width: 50px;
  height: 50px;
  background-color: rgb(241,161,76);
  border-radius: 50%;
`;

const StyledText = styled(Typography.Text)`
  margin: auto;
  font-weight: bolder;
  color: white;
  font-size: x-large;
`;

const StyledUserName = styled(Row)`
  font-weight: bold;
`;

const StyledDateString = styled(Row)`
  font-size: smaller;
`;

export const UserInfo: React.FC<UserInfoProps> = (param: UserInfoProps) => {
    const { name, jobCreatedDateTime } = param;
    return (
        <Row gutter={8} align="middle">
            <Col>
                <StyledCircle>
                    <StyledText>{name.substring(0, 1)}</StyledText>
                </StyledCircle>
            </Col>
            <Col>
                <StyledUserName>{name}</StyledUserName>
                <StyledDateString>{getJobCreatedDateTimeString(jobCreatedDateTime)}</StyledDateString>
            </Col>
        </Row>
    );
}