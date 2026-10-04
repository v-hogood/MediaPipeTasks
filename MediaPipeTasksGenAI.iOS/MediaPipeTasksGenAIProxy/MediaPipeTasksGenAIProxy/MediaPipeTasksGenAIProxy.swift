//
//  MediaPipeTasksGenAIProxy.swift
//  MediaPipeTasksGenAIProxy
//
//  Created by Howard Good on 5/30/26.
//

import Foundation
import MediaPipeTasksGenAI
import MediaPipeTasksGenAIC

@objc(MPPLLMInferenceSession)
extension LlmInference.Session
{
    @objc
    public func sizeInTokensObjC(text: String) throws -> NSNumber
    {
        let tokens = try self.sizeInTokens(text: text)
        return NSNumber(value: tokens)
    }
}
