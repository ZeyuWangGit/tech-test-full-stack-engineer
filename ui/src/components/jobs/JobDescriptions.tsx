import React from 'react';
import styled from 'styled-components';
import { Typography } from 'antd';

interface DescriptionProps {
  text: string;
}

const StyledParagraph = styled(Typography.Paragraph)`
  margin-top: 10px;
`;

export const JobDescription: React.FC<DescriptionProps> = ({ text }) => {
  return <StyledParagraph>{text}</StyledParagraph>;
};